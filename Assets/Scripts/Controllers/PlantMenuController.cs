using System.Collections.Generic;
using UnityEngine;

public class PlantMenuController : State
{
    private PlantMenuItem[] shopItems;

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        SetTitleText("Pick something to grow in a plot");
        spriteGrid.SetButtonText("Go Back");

        shopItems = new PlantMenuItem[SpriteGrid.NUM_CELLS - 1]
        {
            // Fruits and vegetables
            new()
            {
                Name = "Carrot",
                Description = "A healthy carrot",
                IconName = "placeholder",
                TimeToGrow = 5f,
                Yield = 3,
                YieldUnit = "carrots",
                PurchasePrice = 1f,
                SellPrice = 2f,
                IsAnimal = false,
            },
            new()
            {
                Name = "Tomato",
                Description = "A juicy tomato",
                IconName = "placeholder",
                TimeToGrow = 6f,
                Yield = 5,
                YieldUnit = "tomatoes",
                PurchasePrice = 2f,
                SellPrice = 4f,
                IsAnimal = false,
            },
            new()
            {
                Name = "Apple",
                Description = "A sweet apple",
                IconName = "placeholder",
                TimeToGrow = 8f,
                Yield = 6,
                YieldUnit = "apples",
                PurchasePrice = 2.5f,
                SellPrice = 5f,
                IsAnimal = false,
            },
            // Animals
            new()
            {
                Name = "Chicken",
                Description = "A clucking chicken",
                IconName = "placeholder",
                TimeToGrow = 10f,
                Yield = 2,
                YieldUnit = "eggs",
                PurchasePrice = 5f,
                SellPrice = 10f,
                IsAnimal = true,
            },
            new()
            {
                Name = "Cow",
                Description = "A mooing cow",
                IconName = "placeholder",
                TimeToGrow = 20f,
                Yield = 10,
                YieldUnit = "milk",
                PurchasePrice = 20f,
                SellPrice = 40f,
                IsAnimal = true,
            },
            new()
            {
                Name = "Sheep",
                Description = "A baaing sheep",
                IconName = "placeholder",
                TimeToGrow = 15f,
                Yield = 5,
                YieldUnit = "wool",
                PurchasePrice = 10f,
                SellPrice = 20f,
                IsAnimal = true,
            },
        };
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
            Debug.Log("Cancel shop menu");
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
