namespace LIN.Inventory.Shared.Drawers;

public partial class DrawerPeople
{

    /// <summary>
    /// ID del elemento Html.
    /// </summary>
    public string _id = $"element-{Guid.NewGuid()}";


    /// <summary>
    /// Resultado de búsqueda.
    /// </summary>
    private List<Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel>> Result = [];


    /// <summary>
    /// Lista de perfiles seleccionados.
    /// </summary>
    [Parameter]
    public List<Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel>> Selected { get; set; } = [];


    /// <summary>
    /// Evento al ocultar.
    /// </summary>
    [Parameter]
    public Action OnHide { get; set; } = () => { };


    /// <summary>
    /// Evento al mostrar.
    /// </summary>
    [Parameter]
    public Action OnShow { get; set; } = () => { };


    /// <summary>
    /// Buscar.
    /// </summary>
    /// <param name="e">evento.</param>
    public async void Search(ChangeEventArgs e)
    {

        // Si es null o vacío.
        if (e.Value?.ToString()?.Trim() == "")
            return;

        // Encuentra el usuario
        var user = await Access.Inventory.Controllers.Profile.SearchByPattern(e.Value?.ToString() ?? "", Access.Inventory.Session.Instance.AccountToken);

        Result = user.Models.ToList();
        StateHasChanged();
    }


    /// <summary>
    /// Abrir drawer.
    /// </summary>
    public async void Show()
    {
        await JsRuntime.InvokeVoidAsync("showDrawer", _id, DotNetObjectReference.Create(this), "btn-close-panel-ide");
    }


    /// <summary>
    /// Evento al ocultar.
    /// </summary>
    [JSInvokable("OnHide")]
    public void HideJS() => OnHide.Invoke();


    /// <summary>
    /// Evento al abrir.
    /// </summary>
    [JSInvokable("OnShow")]
    public void ShowJS() => OnShow.Invoke();


    /// <summary>
    /// Seleccionar un perfil.
    /// </summary>
    /// <param name="e">Perfil.</param>
    private void Select(Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel> e)
    {
        Selected.Add(e);
    }


    /// <summary>
    /// Deseleccionar un perfil.
    /// </summary>
    /// <param name="profile">Perfil.</param>
    private void UnSelect(int profile)
    {
        Selected.RemoveAll(t => t.Profile.Id == profile);
    }


    /// <summary>
    /// Controlador, Seleccionar / Deseleccionar.
    /// </summary>
    /// <param name="e">Perfil.</param>
    /// <param name="exist">Existe.</param>
    private void SelectControl(Types.Cloud.Identity.Abstracts.SessionModel<Types.Inventory.Models.ProfileModel> e, bool exist)
    {
        // Deseleccionar.
        if (exist)
            UnSelect(e.Profile.Id);

        // Seleccionar.
        else
            Select(e);

        // Notificar estado.
        StateHasChanged();

    }

}