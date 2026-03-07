using System.Collections.Generic;
using UnityEngine;

public class PlantMenuController : State
{
    private PlantMenuItem[] shopItems;

    public PlantMenuController(MainController mainController, StateMachine stateMachine)
        : base(mainController, stateMachine) { }

    public override void SetupSpriteGrid()
    {
        if (shopItems.Length == 6)
        {
            spriteGrid.Setup(this, new List<int> { });
        }
        else
        {
            spriteGrid.Setup(this, new List<int> { 3, 4, 5 });
        }
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        PlotItem plot = mainController.PlotItems[mainController.LastSelectedPlotIndex];
        if (plot.areAnimalsAllowed)
        {
            // If the plot has an animal upgrade, only show animal options
            shopItems = new PlantMenuItem[SpriteGrid.NUM_CELLS - 4]
            {
                // Animals
                new()
                {
                    IconName = "sprites/animals/cow",
                    TimeToGrow = 100f,
                    Yield = 3,
                    PurchasePrice = 60f,
                    SellPrice = 30f,
                    IsAnimal = true,
                },
                new()
                {
                    IconName = "sprites/animals/chicken",
                    TimeToGrow = 100f,
                    Yield = 6,
                    PurchasePrice = 40f,
                    SellPrice = 8f,
                    IsAnimal = true,
                },
                new()
                {
                    IconName = "sprites/animals/bee",
                    TimeToGrow = 150f,
                    Yield = 4,
                    PurchasePrice = 50f,
                    SellPrice = 35f,
                    IsAnimal = true,
                },
            };
        }
        else
        {
            shopItems = new PlantMenuItem[SpriteGrid.NUM_CELLS - 1]
            {
                new()
                {
                    IconName = "sprites/crops/lettuce/lettuce_2",
                    TimeToGrow = 150f,
                    Yield = 1,
                    PurchasePrice = 3f,
                    SellPrice = 30f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/tomato/tomato_2",
                    TimeToGrow = 100f,
                    Yield = 6,
                    PurchasePrice = 3f,
                    SellPrice = 3f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/carrot/carrot",
                    TimeToGrow = 150f,
                    Yield = 5,
                    PurchasePrice = 4f,
                    SellPrice = 4f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/apple/apple",
                    TimeToGrow = 300f,
                    Yield = 8,
                    PurchasePrice = 7f,
                    SellPrice = 8f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/blueberries/blueberry",
                    TimeToGrow = 50f,
                    Yield = 20,
                    PurchasePrice = 10f,
                    SellPrice = 1f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/pumpkin/pumpkin_2",
                    TimeToGrow = 300f,
                    Yield = 4,
                    PurchasePrice = 15f,
                    SellPrice = 15f,
                    IsAnimal = false,
                },
            };
        }

        base.Enter(mainController, stateMachine);

        spriteGrid.SetButtonText("Go Back");
    }

    public override void Tick()
    {
        base.Tick();

        int seedIndex = 0;
        for (int i = 0; i < spriteGrid.sprites.Length; i++)
        {
            GameObject gridCellObject = spriteGrid.sprites[i].gameObject;
            if (!gridCellObject.activeSelf)
            {
                continue;
            }

            if (seedIndex >= shopItems.Length)
            {
                break;
            }

            SpriteGridCell gridCell = gridCellObject.GetComponent<SpriteGridCell>();
            gridCell.RenderPlantMenuItem(shopItems[seedIndex]);
            seedIndex++;
        }
    }

    public override void HandleButtonSelect(int index)
    {
        base.HandleButtonSelect(index);

        // Selected button on the bottom row
        if (index == SpriteGrid.LAST_CELL_INDEX)
        {
            stateMachine.GotoState(mainController.gameController);
            return;
        }

        // On the 3x3 grid
        if (index >= 0 && index <= 8)
        {
            bool wasPlanted = mainController.PlantBeing(shopItems[index]);
            if (wasPlanted)
            {
                stateMachine.GotoState(mainController.gameController);
            }

            return;
        }
    }
}
