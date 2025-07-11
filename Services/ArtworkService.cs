using System.Net.Http.Json;
using gfcf14_art.Models;

namespace gfcf14_art.Services;

public class ArtworkService
{
  private readonly HttpClient _http;
  private readonly IConfiguration _config;

  public ArtworkService(HttpClient http, IConfiguration config)
  {
    _http = http;
    _config = config;
  }

  public async Task<List<Artwork>> GetAllAsync()
  {
    var baseUrl = _config["API_URL"] ?? "";
    return await _http.GetFromJsonAsync<List<Artwork>>($"{baseUrl}/gfcf14-art/artworks") ?? new List<Artwork>();
  }
}
