﻿namespace LIN.Inventory.Shared.Utilities;


public partial class Header
{

    /// <summary>
    /// Mostrar botón de volver atrás.
    /// </summary>
    [Parameter]
    public bool GoBack { get; set; }


    /// <summary>
    /// Titulo de la sección.
    /// </summary>
    [Parameter]
    public string Tittle { get; set; } = string.Empty;


    /// <summary>
    /// Sección derecha.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;

    private void GoBackPage()
    {
        JS.InvokeVoidAsync("backLast");
    }


}