﻿namespace LIN.Inventory.Shared.Popup;

public partial class AlertPopup
{

    [Parameter]
    public Action OnAccept { get; set; } = () => { };

    public string? Content { get; set; }


    /// <summary>
    /// Key.
    /// </summary>
    private string Key { get; init; } = Guid.NewGuid().ToString();


    /// <summary>
    /// Abrir el modal.
    /// </summary>
    public void Show(string content)
    {
        _ = InvokeAsync(() =>
        {
            Content = content;
            StateHasChanged();
            Js.InvokeVoidAsync("showModal", $"popup-modal-{Key}", DotNetObjectReference.Create(this), $"btn-accept-{Key}", $"btn-cancel-{Key}", $"btn-close-{Key}");
        });
    }

}