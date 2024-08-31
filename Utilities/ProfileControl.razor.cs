namespace LIN.Inventory.Shared.Utilities;

public partial class ProfileControl
{

    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel>? Model { get; set; }


    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel>?>? OnClick { get; set; }



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
