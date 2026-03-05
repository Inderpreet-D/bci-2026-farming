using System.Collections.Generic;

public class StateMachine
{
    public MainController mainController;
    public State currentState;

    public StateMachine(MainController mainController)
    {
        this.mainController = mainController;

        new List<State>() {
            mainController.trainingController,
            mainController.tutorialController,
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