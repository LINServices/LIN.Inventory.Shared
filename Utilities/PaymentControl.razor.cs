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
            return "text-money";
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Pending)
            return "text-orange-500";

        return "text-red-500";

    }

    private string GetClassesSvg()
    {
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Approved)
            return "fill-money";
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Pending)
            return "fill-orange-500";

        return "fill-red-500";

    }

    private string GetStatusText()
    {
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Approved)
            return "Aprobado";
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Pending)
            return "Pendiente";
        if (Model?.Status == Types.Payments.Enums.PayStatusEnum.Refunded)
            return "Devuelto";

        return "Rechazado";
    }

}
