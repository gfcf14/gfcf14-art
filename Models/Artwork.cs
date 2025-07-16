namespace gfcf14_art.Models;

public class Artwork
{
  public DateOnly Date { get; set; } = new();
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  public List<Link> Links { get; set; } = new();
}

public class Link
{
  public string ArtworkDate { get; set; } = string.Empty;
  public string Type { get; set; } = string.Empty;
  public string Url { get; set; } = string.Empty;
}
