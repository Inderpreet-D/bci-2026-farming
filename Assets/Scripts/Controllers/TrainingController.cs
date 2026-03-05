using UnityEngine;

public class TrainingController : State
{
    const float TRAINING_DELAY = 5.0f;
    private float elapsedTime;

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        elapsedTime = 0.0f;
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
