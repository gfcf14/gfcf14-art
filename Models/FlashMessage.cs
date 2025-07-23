namespace gfcf14_art.Models;

public class FlashMessage
{
  public string Message { get; set; } = string.Empty;
  public string Type { get; set; } = "success"; // "success" or "error"
}
