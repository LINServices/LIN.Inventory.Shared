using LIN.Access.Inventory;
using LIN.Types.Inventory.Enumerations;

namespace LIN.Inventory.Shared.Popup;

public partial class MemberPopup
{

    /// <summary>
    /// Modelo de contacto.
    /// </summary>
    private IntegrantDataModel? _data;


    /// <summary>
    /// Obtener / Establecer el modelo.
    /// </summary>
    [Parameter]
    public IntegrantDataModel? Model
    {
        get => _data;
        set
        {
            _data = value;
            InvokeAsync(StateHasChanged);
        }
    }


    /// <summary>
    /// Obtener / Establecer el modelo.
    /// </summary>
    [Parameter]
    public Action OnSuccess { get; set; } = () => { };


    /// <summary>
    /// Acción al presionar sobre el botón de eliminar.
    /// </summary>
    [Parameter]
    public Action<int> OnDelete { get; set; } = (id) => { };



    private int _type = 0;
    int Type
    {
        get => _type; set
        {
            _type = value;
            InvokeAsync(StateHasChanged);
        }

    }


    /// <summary>
    /// Abrir el popup.
    /// </summary>
    public async void Show()
    {
        try
        {
            // Abrir el popup.
            await Js.InvokeVoidAsync("ShowModal", "small-modal-member", "closeee-member", "close-btn-send-member");
            StateHasChanged();
        }
        catch (Exception)
        {
        }
    }


    /// <summary>
    /// Abrir el popup.
    /// </summary>
    public void Show(IntegrantDataModel contact)
    {
        Model = contact;
        _type = (int)Model.Rol;
        Show();
    }


    /// <summary>
    /// Actualizar el rol.
    /// </summary>
    private async void Change(Microsoft.AspNetCore.Components.ChangeEventArgs e)
    {
        // Obtener el rol.
        var newRol = int.Parse(e.Value?.ToString() ?? "0");

        // Validación.
        if (Model is null)
            return;

        // Enviar update.
        var response = await Access.Inventory.Controllers.InventoryAccess.UpdateRol(Model.AccessID, (InventoryRoles)newRol, Session.Instance.Token);

        if (response.Response == Responses.Success)
        {
            Model.Rol = (InventoryRoles)newRol;
            OnSuccess();
        }
    }


    /// <summary>
    /// Eliminar integrante.
    /// </summary>
    async void Delete()
    {

        // Validación.
        if (Model is null)
            return;

        // Enviar petición.
        var response = await Access.Inventory.Controllers.InventoryAccess.DeleteSomeOne(Model.InventoryID, Model.ProfileID, Session.Instance.Token);

        if (response.Response == Responses.Success)
            OnDelete(Model.AccessID);
    }

}