using UnityEngine;

public class UpgradeMenuController : State
{
    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        SetTitleText("Pick an upgrade to buy");

        spriteGrid.SetButtonText("Go Back");
    }

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
            bool wasUpgraded = mainController.ApplyUpgrade(index);
            if (wasUpgraded)
            {
                stateMachine.GotoState(mainController.gameController);
            }

            return;
        }
    }
}
