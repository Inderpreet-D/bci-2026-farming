using UnityEngine;

public class GameController : State
{
    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);
    }

    public override void Tick()
    {
        base.Tick();
        Debug.Log("INDER tick game");
    }
}
