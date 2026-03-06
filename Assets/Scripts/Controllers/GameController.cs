using UnityEngine;

public class GameController : State
{
    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        SetTitleText("Any game text goes up here");

        spriteGrid.SetButtonText("Upgrade");
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == 9)
        {
            Debug.Log("Open upgrade menu");
            stateMachine.GotoState(mainController.upgradeMenuController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            // TODO Store which grid was selected for planting
            Debug.Log("Open plant menu");
            stateMachine.GotoState(mainController.plantMenuController);
            return;
        }
    }
}
