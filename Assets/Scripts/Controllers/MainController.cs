using UnityEngine;

public class MainController : MonoBehaviour
{
    public State trainingController;
    public State tutorialController;
    public State gameController;
    public State upgradeMenuController;
    public State plantMenuController;

    StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine(this);
    }

    void Update()
    {
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
    }
}
