using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public SpriteGrid spriteGrid;

    protected MainController mainController;
    protected StateMachine stateMachine;

    public virtual void SetupSpriteGrid()
    {
        spriteGrid.Setup(this, new List<int> { 10 });
    }

    public virtual void Enter(MainController mainController, StateMachine stateMachine)
    {
        gameObject.SetActive(true);
        this.mainController = mainController;
        this.stateMachine = stateMachine;
        SetupSpriteGrid();
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public virtual void Tick() { }

    public virtual void HandleButtonSelect(int index)
    {
        Debug.Log("Button pressed: " + index.ToString());
    }
}

public class StateMachine
{
    public MainController mainController;
    public State currentState;

    public StateMachine(MainController mainController)
    {
        this.mainController = mainController;

        new List<State>() {
            mainController.trainingController,
            mainController.gameController,
            mainController.upgradeMenuController,
            mainController.plantMenuController
        }.ForEach(obj => obj.gameObject.SetActive(false));

        GotoState(mainController.trainingController);
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
