namespace LIN.Inventory.Shared.Drawers;

public partial class ClientsDrawer
{

    /// <summary>
    /// ID del elemento Html.
    /// </summary>
    public string _id = $"element-{Guid.NewGuid()}";


    /// <summary>
    /// Resultado de búsqueda.
    /// </summary>
    private List<OutsiderModel> Result = [];


    /// <summary>
    /// Lista de perfiles seleccionados.
    /// </summary>
    [Parameter]
    public OutsiderModel? Selected { get; set; } = null;


    [Parameter]
    public int Inventory { get; set; } = 0;


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
        var user = await Access.Inventory.Controllers.Profile.SearchOutsiders(e.Value?.ToString() ?? "", Inventory, Access.Inventory.Session.Instance.Token);

        Result = [.. user.Models];
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
    private void Select(OutsiderModel e)
    {
        Selected = e;
    }


    /// <summary>
    /// Deseleccionar un perfil.
    /// </summary>
    /// <param name="profile">Perfil.</param>
    private void UnSelect(int id)
    {
        Selected = null;
    }


    /// <summary>
    /// Controlador, Seleccionar / Deseleccionar.
    /// </summary>
    /// <param name="e">Perfil.</param>
    /// <param name="exist">Existe.</param>
    private void SelectControl(OutsiderModel e, bool exist)
    {
        // Deseleccionar.
        if (exist)
            UnSelect(e.Id);

        // Seleccionar.
        else
            Select(e);

        // Notificar estado.
        StateHasChanged();
    }

}