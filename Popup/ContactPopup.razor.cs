namespace LIN.Inventory.Shared.Popup;

public partial class ContactPopup
{

    /// <summary>
    /// Acción al presionar sobre el botón de editar.
    /// </summary>
    [Parameter]
    public Action<ContactModel> OnEdit { get; set; } = (e) => { };


    /// <summary>
    /// Key.
    /// </summary>
    private string Key { get; init; } = Guid.NewGuid().ToString();


    /// <summary>
    /// Modelo del contacto.
    /// </summary>
    public ContactModel? Modelo { get; set; }


    /// <summary>
    /// Abrir el modal.
    /// </summary>
    public void Show(ContactModel model)
    {
        Modelo = model;
        _ = InvokeAsync(() =>
        {
            StateHasChanged();
            Js.InvokeVoidAsync("showModal", $"modal-{Key}", DotNetObjectReference.Create(this), $"btn-{Key}", "close-btn-send");
        });
    }


    /// <summary>
    /// Imagen en base64.
    /// </summary>
    private string Img64 => Convert.ToBase64String(Modelo?.Picture ?? []);


    /// <summary>
    /// Enviar el comando al selector.
    /// </summary>
    private void Send()
    {
        // Nuevo onInvoque.
        devices.Send($"viewContact({Modelo?.Id})");
    }

}