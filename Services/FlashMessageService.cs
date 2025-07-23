using gfcf14_art.Models;

namespace gfcf14_art.Services;

public class FlashMessageService
{
  public event Action? OnMessageChanged;
  private FlashMessage? _message;
  private System.Timers.Timer? _dismissTimer;

  public FlashMessage? CurrentMessage => _message;

  public void Show(string message, string type)
  {
    _message = new FlashMessage { Message = message, Type = type };
    OnMessageChanged?.Invoke();

    _dismissTimer?.Stop();
    _dismissTimer = new System.Timers.Timer(5000);
    _dismissTimer.Elapsed += (s, e) =>
    {
      _message = null;
      OnMessageChanged?.Invoke();
      _dismissTimer?.Stop();
    };
    _dismissTimer.Start();
  }
}
