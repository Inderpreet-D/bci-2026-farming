using UnityEngine;

public class UpgradeMenuController : State
{
    public UpgradeMenuController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        spriteGrid.SetButtonText("Go Back");
    }

    public override void Tick()
    {
        base.Tick();

        Debug.Log("Upgrade menu tick: " + mainController.PlotItems.Length);

        for (int i = 0; i < mainController.PlotItems.Length; i++)
        {
            PlotItem plot = mainController.PlotItems[i];
            UpgradeMenuItem upgrade = plot.Upgrade;
            SpriteGridCell cell = spriteGrid.sprites[i];
            cell.RenderUpgradeItem(upgrade);
        }
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == SpriteGrid.LAST_CELL_INDEX)
        {
            Debug.Log("Cancel upgrade menu");
            stateMachine.GotoState(mainController.gameController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            bool wasUpgraded = mainController.ApplyUpgrade(index);
            if (wasUpgraded)
            {
                stateMachine.GotoState(mainController.gameController);
            }

            return;
        }
    }
}
