namespace LIN.Inventory.Shared.Drawers;

public partial class EmmaDrawer
{

    /// <summary>
    /// ID del elemento Html.
    /// </summary>
    public string _id = $"element-{Guid.NewGuid()}";


    /// <summary>
    /// Emma drawer.
    /// </summary>
    private Emma.UI.Emma? DocEmma { get; set; }


    /// <summary>
    /// Abrir el elemento.
    /// </summary>
    public async void Show()
    {
        // Abrir el elemento.
        await JsRuntime.InvokeVoidAsync("showDrawer", _id, DotNetObjectReference.Create(this), $"btn-close-{_id}", "close-all-all");
    }


    /// <summary>
    /// Después de renderizar.
    /// </summary>
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender && DocEmma is not null)
        {
            DocEmma.OnPromptRequire += DocEmma_OnPromptRequire;
        }

    }


    /// <summary>
    /// Al recibir respuesta de Emma.
    /// </summary>
    private void DocEmma_OnPromptRequire(object? sender, string e)
    {
        if (DocEmma != null)
            DocEmma.ResponseIA = Access.Inventory.Controllers.Profile.ToEmma(e, Access.Inventory.Session.Instance.AccountToken);
    }

}