namespace LIN.Inventory.Shared.Utilities;


public partial class OutflowControl
{


    /// <summary>
    /// Modelo del producto.
    /// </summary>
    [Parameter]
    public OutflowDataModel? Model { get; set; }



    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<OutflowDataModel?>? OnClick { get; set; }



    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }



    private string GetImage()
    {



        return Model.Type switch
        {
            Types.Inventory.Enumerations.OutflowsTypes.Usage => "./img/Products/outflows/seller.png",
            Types.Inventory.Enumerations.OutflowsTypes.Contribution => "./img/Products/outflows/donate.png",
            Types.Inventory.Enumerations.OutflowsTypes.Fraud => "./img/Products/outflows/criminal.png",
            Types.Inventory.Enumerations.OutflowsTypes.Purchase => "./img/Products/outflows/shop.png",
            Types.Inventory.Enumerations.OutflowsTypes.Loss => "./img/Products/outflows/lost.png",
            Types.Inventory.Enumerations.OutflowsTypes.Expiry => "./img/Products/outflows/expired.png",
            _ => "./img/Products/packages.png",
        };
    }

}