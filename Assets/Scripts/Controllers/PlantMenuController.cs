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
                    IconName = "sprites/animals/cow/cow",
                    TimeToGrow = 50f,
                    Yield = 3,
                    PurchasePrice = 75f,
                    SellPrice = 30f,
                    IsAnimal = true,
                },
                new()
                {
                    IconName = "sprites/animals/chicken/chicken",
                    TimeToGrow = 50f,
                    Yield = 6,
                    PurchasePrice = 40f,
                    SellPrice = 8f,
                    IsAnimal = true,
                },
                new()
                {
                    IconName = "sprites/animals/bee/bee",
                    TimeToGrow = 100f,
                    Yield = 4,
                    PurchasePrice = 80f,
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
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/lettuce/lettuce_1",
                        "sprites/crops/lettuce/lettuce_2",
                    },
                    TimeToGrow = 100f,
                    Yield = 1,
                    PurchasePrice = 15f,
                    SellPrice = 30f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/tomato/tomato_2",
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/tomato/tomato_1",
                        "sprites/crops/tomato/tomato_2",
                    },
                    TimeToGrow = 50f,
                    Yield = 6,
                    PurchasePrice = 10f,
                    SellPrice = 3f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/carrot/carrot",
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/carrot/carrot_1",
                        "sprites/crops/carrot/carrot_2",
                    },
                    TimeToGrow = 75f,
                    Yield = 5,
                    PurchasePrice = 12f,
                    SellPrice = 4f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/apple/apple",
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/apple/apple_tree",
                        "sprites/crops/apple/apple_tree_grown",
                    },
                    TimeToGrow = 150f,
                    Yield = 8,
                    PurchasePrice = 50f,
                    SellPrice = 8f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/blueberries/blueberry",
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/blueberries/blueberry_bush_1",
                        "sprites/crops/blueberries/blueberry_bush_2",
                    },
                    TimeToGrow = 25f,
                    Yield = 20,
                    PurchasePrice = 10f,
                    SellPrice = 1f,
                    IsAnimal = false,
                },
                new()
                {
                    IconName = "sprites/crops/pumpkin/pumpkin_2",
                    GrowthStageIconNames = new string[]
                    {
                        "sprites/general/seeds",
                        "sprites/crops/pumpkin/pumpkin_1",
                        "sprites/crops/pumpkin/pumpkin_2",
                    },
                    TimeToGrow = 150f,
                    Yield = 4,
                    PurchasePrice = 25f,
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
