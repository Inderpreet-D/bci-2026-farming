using UnityEngine;

public class GameController : State
{
    public GameController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        spriteGrid.SetButtonText("Upgrade");
    }

    public override void Tick()
    {
        base.Tick();

        Debug.Log("Num plots: " + mainController.PlotItems.Length);
        for (int i = 0; i < spriteGrid.sprites.Length; i++)
        {
            if (i >= mainController.PlotItems.Length)
            {
                break;
            }

            PlotItem plot = mainController.PlotItems[i];
            plot.Tick();

            if (plot.IsFullyGrown())
            {
                plot.Harvest(this);
            }

            SpriteGridCell spriteGridCell = spriteGrid.sprites[i];
            spriteGridCell.RenderPlotItem(plot);
        }
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == SpriteGrid.LAST_CELL_INDEX)
        {
            stateMachine.GotoState(mainController.upgradeMenuController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            mainController.LastSelectedPlotIndex = index;
            stateMachine.GotoState(mainController.plantMenuController);
            return;
        }
    }
}
