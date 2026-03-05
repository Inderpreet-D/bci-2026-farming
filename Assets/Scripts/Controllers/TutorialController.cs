using UnityEngine;

public class TutorialController : State
{
    const float TUTORIAL_DELAY = 1.0f; //5.0f;
    private float elapsedTime;

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        elapsedTime = 0.0f;

        SetTitleText("Tutorial goes here");
    }

    public override void Tick()
    {
        base.Tick();

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= TUTORIAL_DELAY)
        {
            stateMachine.GotoState(stateMachine.mainController.gameController);
        }
    }
}
