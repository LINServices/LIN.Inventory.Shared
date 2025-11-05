namespace LIN.Inventory.Shared.Services;

public class ToastService
{
    public event Action<(string, int)>? OnShow;

    public Task ShowAsync(string message)
    {
        OnShow?.Invoke((message, 1));
        return Task.CompletedTask;
    }

    public Task ShowErrorAsync(string message)
    {
        OnShow?.Invoke((message, 2));
        return Task.CompletedTask;
    }

    public Task ShowWarningAsync(string message)
    {
        OnShow?.Invoke((message, 3));
        return Task.CompletedTask;
    }
}
