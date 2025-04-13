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

    private string GetClasses()
    {
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Approved)
            return "bg-money text-white";
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Pending)
            return "bg-orange-500 text-white";

        return "bg-red-500 text-white";

    }

}
