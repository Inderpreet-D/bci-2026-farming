using UnityEngine;

public class TrainingController : State
{
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
        if (elapsedTime >= 5.0f)
        {
            stateMachine.GotoState(stateMachine.gameState);
        }
        Debug.Log("INDER tick TrainingController");
    }
}
