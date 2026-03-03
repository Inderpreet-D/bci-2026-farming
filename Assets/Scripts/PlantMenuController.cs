using UnityEngine;

public class PlantMenuController : State
{
    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == 9)
        {
            Debug.Log("Cancel plant menu");
            stateMachine.GotoState(mainController.gameController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            Debug.Log("Plant seed at " + index);
            // TODO Handle the planting logic
            stateMachine.GotoState(mainController.gameController);
            return;
        }
    }
}