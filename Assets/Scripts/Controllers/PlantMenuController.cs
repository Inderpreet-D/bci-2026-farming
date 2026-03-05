using System.Collections.Generic;
using UnityEngine;

public class PlantMenuController : State
{
    private PlotItem[] seeds;

    public override void SetupSpriteGrid()
    {
        spriteGrid.Setup(this, new List<int> { 6, 7, 8, 10 });
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        seeds = new PlotItem[]
        {
            // Seeds
            new PlotItem("Carrot", "A healthy carrot", "placeholder", 5f, 3, "pcs", 1f, 2f, false),
            new PlotItem(
                "Potato",
                "A starchy potato",
                "placeholder",
                7f,
                4,
                "pcs",
                1.5f,
                3f,
                false
            ),
            new PlotItem("Tomato", "A juicy tomato", "placeholder", 6f, 5, "pcs", 2f, 4f, false),
            // Animals
            new PlotItem(
                "Chicken",
                "A clucking chicken",
                "placeholder",
                10f,
                2,
                "eggs/day",
                5f,
                10f,
                true
            ),
            new PlotItem("Cow", "A mooing cow", "placeholder", 20f, 10, "milk/day", 20f, 40f, true),
            new PlotItem(
                "Sheep",
                "A baaing sheep",
                "placeholder",
                15f,
                5,
                "wool/day",
                10f,
                20f,
                true
            ),
        };
    }

    // TODO make sprite update logic

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
