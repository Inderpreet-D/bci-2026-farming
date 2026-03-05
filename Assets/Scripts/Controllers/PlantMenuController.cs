using System.Collections.Generic;
using UnityEngine;

public class PlantMenuController : State
{
    private PlantMenuItem[] shopItems;

    public override void SetupSpriteGrid()
    {
        spriteGrid.Setup(this, new List<int> { 6, 7, 8 });
    }

    public override void Enter(MainController mainController, StateMachine stateMachine)
    {
        base.Enter(mainController, stateMachine);

        SetTitleText("Pick something to grow in a plot");

        shopItems = new PlantMenuItem[]
        {
            // Fruits and vegetables
            new()
            {
                name = "Carrot",
                description = "A healthy carrot",
                iconName = "placeholder",
                timeToGrow = 5f,
                yield = 3,
                yieldUnit = "pcs",
                purchasePrice = 1f,
                sellPrice = 2f,
                isAnimal = false,
            },
            new()
            {
                name = "Tomato",
                description = "A juicy tomato",
                iconName = "placeholder",
                timeToGrow = 6f,
                yield = 5,
                yieldUnit = "pcs",
                purchasePrice = 2f,
                sellPrice = 4f,
                isAnimal = false,
            },
            new()
            {
                name = "Apple",
                description = "A sweet apple",
                iconName = "placeholder",
                timeToGrow = 8f,
                yield = 6,
                yieldUnit = "pcs",
                purchasePrice = 2.5f,
                sellPrice = 5f,
                isAnimal = false,
            },
            // Animals
            new()
            {
                name = "Chicken",
                description = "A clucking chicken",
                iconName = "placeholder",
                timeToGrow = 10f,
                yield = 2,
                yieldUnit = "eggs",
                purchasePrice = 5f,
                sellPrice = 10f,
                isAnimal = true,
            },
            new()
            {
                name = "Cow",
                description = "A mooing cow",
                iconName = "placeholder",
                timeToGrow = 20f,
                yield = 10,
                yieldUnit = "milk",
                purchasePrice = 20f,
                sellPrice = 40f,
                isAnimal = true,
            },
            new()
            {
                name = "Sheep",
                description = "A baaing sheep",
                iconName = "placeholder",
                timeToGrow = 15f,
                yield = 5,
                yieldUnit = "wool",
                purchasePrice = 10f,
                sellPrice = 20f,
                isAnimal = true,
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
        if (index == 9)
        {
            Debug.Log("Cancel shop menu");
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
