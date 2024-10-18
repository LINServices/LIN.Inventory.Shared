
using LIN.Access.Inventory;
using LIN.Types.Inventory.Enumerations;
using LIN.Types.Inventory.Transient;

namespace LIN.Inventory.Shared.Utilities;

public partial class InvitationControl
{


    [Parameter]
    public Notificacion Model { get; set; }


    [Parameter]
    public List<Notificacion> Models { get; set; }


    [Parameter]
    public Action OnRemove { get; set; }

    private int section = 1;

    private async void Accept()
    {
        int id = Model.ID;
        section = 0;
        StateHasChanged();
        var response = await Access.Inventory.Controllers.InventoryAccess.UpdateState(Session.Instance.Token, id, InventoryAccessState.Accepted);

        if (response.Response != Responses.Success)
        {
            section = 2;
            StateHasChanged();
        }

        Models.Remove(Model);
        OnRemove();

        section = 1;
        UpRealTime(id);
        StateHasChanged();

    }

    private async void Decline()
    {

        int id = Model.ID;

        section = 0;
        StateHasChanged();
        var response = await Access.Inventory.Controllers.InventoryAccess.UpdateState(Session.Instance.Token, id, InventoryAccessState.Deleted);

        if (response.Response != Responses.Success)
        {
            section = 2;
            StateHasChanged();
        }

        Models.Remove(Model);
        OnRemove();

        section = 1;
        UpRealTime(id);
        StateHasChanged();

    }

    private async void UpRealTime(int id)
    {
        await deviceManager.SendCommand($"newStateInvitation({id})");
    }

}
