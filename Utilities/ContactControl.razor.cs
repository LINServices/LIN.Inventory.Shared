global using LIN.Types.Contacts.Models;

namespace LIN.Inventory.Shared.Utilities;

public partial class ContactControl
{


    /// <summary>
    /// Modelo.
    /// </summary>
    [Parameter]
    public ContactModel? Model { get; set; }


    /// <summary>
    /// Evento al hacer click.
    /// </summary>
    [Parameter]
    public Action<ContactModel?>? OnClick { get; set; }


    /// <summary>
    /// Enviar el evento.
    /// </summary>
    private void SendEvent()
    {
        OnClick?.Invoke(Model);
    }

    private string Img64 => Convert.ToBase64String(Model?.Picture ?? []);


}