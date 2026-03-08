using UnityEngine;

public class Contracts : State
{
    public Contracts(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        spriteGrid.SetButtonText("Back");
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == SpriteGrid.LAST_CELL_INDEX)
        {
            stateMachine.GotoState(mainController.gameController);
            return;
        }
    }
}