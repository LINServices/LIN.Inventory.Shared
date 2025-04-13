namespace LIN.Inventory.Shared.Utilities;

public partial class HoldControl
{

    /// <summary>
    /// Modelo del producto.
    /// </summary>
    [Parameter]
    public HoldModel? Model { get; set; }



    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<HoldModel?>? OnClick { get; set; }



    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }

}