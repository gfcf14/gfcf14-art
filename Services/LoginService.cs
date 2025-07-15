using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using gfcf14_art.Models;

namespace gfcf14_art.Services;

public class LoginService
{
  private readonly HttpClient _http;
  private readonly IConfiguration _config;
  private readonly string baseUrl;

  public LoginService(HttpClient http, IConfiguration config)
  {
    _http = http;
    _config = config;
    baseUrl = _config["API_URL"] ?? throw new InvalidOperationException("API_URL not set");
  }

  public async Task<TokenResponse> LoginAsync(string username, string password)
  {
    var response = await _http.PostAsJsonAsync($"{baseUrl}/login", new { username, password });
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<TokenResponse>() ?? throw new Exception("No token received");
  }

  public bool IsTokenValid(string token)
  {
    try
    {
      var payload = token.Split('.')[1];
      var json = Encoding.UTF8.GetString(Convert.FromBase64String(PadBase64(payload)));
      using var doc = JsonDocument.Parse(json);
      var exp = doc.RootElement.GetProperty("exp").GetInt64();
      return DateTimeOffset.UtcNow.ToUnixTimeSeconds() < exp;
    }
    catch
    {
      return false;
    }
  }

  private string PadBase64(string base64)
  {
    return base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
  }
}
