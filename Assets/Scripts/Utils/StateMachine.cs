using System.Collections.Generic;

public class StateMachine
{
    public MainController mainController;
    public State currentState;

    public StateMachine(MainController mainController)
    {
        this.mainController = mainController;
    }

    public void Update()
    {
        if (currentState == null)
        {
            return;
        }

        if (!currentState.IsActive)
        {
            return;
        }

        currentState.Tick();
    }

    public void GotoState(State newState)
    {
        if (currentState == null)
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
