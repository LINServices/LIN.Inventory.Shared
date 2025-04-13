namespace LIN.Inventory.Shared.Utilities;

public partial class ClientControl
{

    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public OutsiderModel Model { get; set; }

    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<OutsiderModel>? OnClick { get; set; }

    /// <summary>
    /// Estado.
    /// </summary>
    [Parameter]
    public bool State { get; set; }

    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }
}