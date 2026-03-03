using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected MainController mainController;
    protected StateMachine stateMachine;


    public virtual void Enter(MainController mainController, StateMachine stateMachine)
    {
        gameObject.SetActive(true);
        this.mainController = mainController;
        this.stateMachine = stateMachine;
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public virtual void Tick() { }
}

public class StateMachine
{
    public MainController mainController;
    public State trainingState;
    public State gameState;
    public State currentState;

    public StateMachine(MainController mainController, State trainingState, State gameState)
    {
        this.mainController = mainController;

        this.trainingState = trainingState;
        this.gameState = gameState;

        new List<State>() {
            trainingState,
            gameState
        }.ForEach(obj => obj.gameObject.SetActive(false));

        GotoState(trainingState);
    }
    public void Update()
    {
        if (!currentState)
        {
            return;
        }

        currentState.Tick();
    }

    public void GotoState(State newState)
    {
        if (!currentState)
        {
            currentState = newState;
            Debug.Log("A");
            Debug.Log(newState);
            Debug.Log("B");
            currentState.Enter(mainController, this);
            return;
        }

        if (newState == currentState)
        {
            return;
        }

        currentState.Exit();

        currentState = newState;

        currentState.Enter(mainController, this);
    }
}

public class MainController : MonoBehaviour
{
    public State trainingController;
    public State gameController;

    StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine(this, trainingController, gameController);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
