using System.Collections.Generic;
using UnityEngine;

public class GameController : State
{
    public const int NUM_DAYS = 5;
    public const float DAY_LENGTH_SECONDS = 5f * 60f;
    public int currentDay = 0;
    public float elapsed = 0.0f;

    public Dictionary<string, float> stats = new();

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

        elapsed += Time.deltaTime;
        if (elapsed >= DAY_LENGTH_SECONDS)
        {
            elapsed = 0f;
            currentDay++;
            Debug.Log($"Day {currentDay} starting!");

            if (currentDay >= NUM_DAYS)
            {
                stateMachine.GotoState(mainController.endScreenController);
                return;
            }
        }

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
                float yield = plot.Harvest(this);
                if (!stats.ContainsKey(plot.Being.IconName))
                {
                    stats[plot.Being.IconName] = 0f;
                }
                stats[plot.Being.IconName] += yield;
            }

            SpriteGridCell spriteGridCell = spriteGrid.sprites[i];
            spriteGridCell.RenderPlotItem(plot);
        }

        // TODO Show day progress ui here

        // TODO Update board ui here
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
        if (index >= 0 && index <= SpriteGrid.NUM_CELLS - 1)
        {
            PlotItem plot = mainController.PlotItems[index];
            if (plot.IsEmpty())
            {
                mainController.LastSelectedPlotIndex = index;
                stateMachine.GotoState(mainController.plantMenuController);
            }

            return;
        }
    }
}
