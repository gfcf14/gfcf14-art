using System.Net.Http.Headers;
using System.Net.Http.Json;
using gfcf14_art.Models;

namespace gfcf14_art.Services;

public class ArtworkService
{
  private readonly HttpClient _http;
  private readonly IConfiguration _config;
  private readonly string baseUrl;

  public ArtworkService(HttpClient http, IConfiguration config)
  {
    _http = http;
    _config = config;
    baseUrl = _config["API_URL"] ?? throw new InvalidOperationException("API_URL not set");
  }

  public async Task<List<Artwork>> GetAllAsync()
  {
    return await _http.GetFromJsonAsync<List<Artwork>>($"{baseUrl}/gfcf14-art/artworks") ?? new List<Artwork>();
  }

  public async Task CreateAsync(Artwork artwork, string token)
  {
    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var response = await _http.PostAsJsonAsync<Artwork>($"{baseUrl}/gfcf14-art/artworks", artwork);
    response.EnsureSuccessStatusCode();

    _http.DefaultRequestHeaders.Authorization = null;
  }
}
