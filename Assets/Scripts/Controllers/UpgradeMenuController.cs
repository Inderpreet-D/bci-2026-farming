using UnityEngine;

public class UpgradeMenuController : State
{
    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == 9)
        {
            Debug.Log("Cancel upgrade menu");
            stateMachine.GotoState(mainController.gameController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            Debug.Log("Selected plot to upgrade " + index);
            // TODO Handle the upgrade logic
            stateMachine.GotoState(mainController.gameController);
            return;
        }
    }
}
