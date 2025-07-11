namespace gfcf14_art.Services;

public class LoaderService
{
  public event Action? OnChange;
  public bool IsLoading { get; private set; }

  public void Show()
  {
    IsLoading = true;
    Notify();
  }

  public void Hide()
  {
    IsLoading = false;
    Notify();
  }

  private void Notify() => OnChange?.Invoke();
}