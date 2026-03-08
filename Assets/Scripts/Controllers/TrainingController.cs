using UnityEngine;

public class TrainingController : State
{
    public TrainingController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void SetupSpriteGrid()
    {
        base.SetupSpriteGrid();

        spriteGrid.RenderAllEmpty();
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        mainController.trainingText.gameObject.SetActive(true);
        mainController.marketParent.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();

        mainController.trainingText.gameObject.SetActive(false);
        mainController.marketParent.SetActive(true);
    }

    public override void Tick()
    {
        base.Tick();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.GotoState(stateMachine.mainController.gameController);
            return;
        }
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        Debug.Log($"Selected training button index: {index}");
    }
}
