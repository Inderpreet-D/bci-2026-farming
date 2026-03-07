using UnityEngine;

public class EndScreenController : State
{
    public EndScreenController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void SetupSpriteGrid()
    {
        base.SetupSpriteGrid();

        spriteGrid.RenderAllEmpty();
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        // TODO Show ui here
    }
}
