namespace LIN.Inventory.Shared.Utilities;

public partial class PaymentControl
{

    /// <summary>
    /// Modelo del producto.
    /// </summary>
    [Parameter]
    public LIN.Types.Payments.Models.PayModel? Model { get; set; }



    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<LIN.Types.Payments.Models.PayModel?>? OnClick { get; set; }



    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }



}
