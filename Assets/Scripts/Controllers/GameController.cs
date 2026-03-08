using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : State
{
    public const float DAY_LENGTH_SECONDS = 5f * 60f;
    public float elapsed = 0.0f;

    public Dictionary<string, float> stats = new();

    public GameController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        spriteGrid.SetButtonText("Upgrade");
    }

    private void UpdateStatsUI()
    {
        mainController.blueberryText.text = MathF
            .Round(stats.GetValueOrDefault("blueberry", 0f))
            .ToString();
        mainController.tomatoText.text = MathF
            .Round(stats.GetValueOrDefault("tomato", 0f))
            .ToString();
        mainController.eggText.text = MathF
            .Round(stats.GetValueOrDefault("chicken", 0f))
            .ToString();
        mainController.appleText.text = MathF
            .Round(stats.GetValueOrDefault("apple", 0f))
            .ToString();
        mainController.lettuceText.text = MathF
            .Round(stats.GetValueOrDefault("lettuce", 0f))
            .ToString();
        mainController.honeyText.text = MathF.Round(stats.GetValueOrDefault("bee", 0f)).ToString();
        mainController.pumpkinText.text = MathF
            .Round(stats.GetValueOrDefault("pumpkin", 0f))
            .ToString();
        mainController.carrotText.text = MathF
            .Round(stats.GetValueOrDefault("carrot", 0f))
            .ToString();
        mainController.milkText.text = MathF.Round(stats.GetValueOrDefault("cow", 0f)).ToString();
    }

    public override void Tick()
    {
        base.Tick();

        elapsed += Time.deltaTime;
        if (elapsed >= DAY_LENGTH_SECONDS)
        {
            stateMachine.GotoState(mainController.endScreenController);
            return;
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
                string id = plot.Being.ID;
                float yield = plot.Harvest(this);
                if (!stats.ContainsKey(id))
                {
                    stats[id] = 0f;
                }
                stats[id] += yield;
            }

            SpriteGridCell spriteGridCell = spriteGrid.sprites[i];
            spriteGridCell.RenderPlotItem(plot);
        }

        int timeRemaining = Mathf.FloorToInt(DAY_LENGTH_SECONDS - elapsed);
        mainController.timeText.text = $"{timeRemaining} seconds left";

        UpdateStatsUI();
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
