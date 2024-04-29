global using Microsoft.AspNetCore.Components;
global using Microsoft.JSInterop;

namespace LIN.Inventory.Shared.Popup;


public partial class AlertPopup
{


    [Parameter]
    public Action OnAccept { get; set; } = () => { };


    public string Content { get; set; }



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
            Js.InvokeVoidAsync("ShowModal", $"popup-modal-{Key}", $"btn-accept-{Key}", $"btn-cancel-{Key}", $"btn-close-{Key}");

        });

    }


}