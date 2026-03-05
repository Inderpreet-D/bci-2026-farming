using UnityEngine;

public class TrainingController : State
{
    const float TRAINING_DELAY = 1.0f; //5.0f;
    private float elapsedTime;

    public override void SetupSpriteGrid()
    {
        base.SetupSpriteGrid();

        spriteGrid.RenderAllEmpty();
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        elapsedTime = 0.0f;

        SetTitleText("In the training mode");
    }

    public override void Tick()
    {
        base.Tick();

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= TRAINING_DELAY)
        {
            stateMachine.GotoState(stateMachine.mainController.tutorialController);
        }
    }
}
