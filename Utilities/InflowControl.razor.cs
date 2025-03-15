namespace LIN.Inventory.Shared.Utilities;


public partial class InflowControl
{


    /// <summary>
    /// Modelo del producto.
    /// </summary>
    [Parameter]
    public InflowDataModel? Model { get; set; }



    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<InflowDataModel?>? OnClick { get; set; }



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
            Types.Inventory.Enumerations.InflowsTypes.Purchase => "./img/Products/inflows/cart.png",
            Types.Inventory.Enumerations.InflowsTypes.Refund => "./img/Products/inflows/return.png",
            Types.Inventory.Enumerations.InflowsTypes.Gift => "./img/Products/inflows/gift.png",
            Types.Inventory.Enumerations.InflowsTypes.Correction => "./img/Products/inflows/setting.png",
            _ => "./img/Products/packages.png",
        };
    }

}