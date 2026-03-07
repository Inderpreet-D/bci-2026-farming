using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteGrid
{
    public const int NUM_CELLS = 7;
    public const int LAST_CELL_INDEX = NUM_CELLS - 1;
    public float delay = 0.3f;
    public SpriteGridCell[] sprites;

    // private float elapsed = 0.0f;
    // private int index = 0;
    private State parentState;
    private InputAction selectAction;
    private List<int> hiddenIndices;

    public void Setup(State parentState, List<int> hiddenIndices)
    {
        sprites = parentState.mainController.GetAllSpriteGridCells();
        Debug.Log("Found " + sprites.Length + " sprites in the grid");
        for (int i = 0; i < sprites.Length; i++)
        {
            Debug.Log(
                "Sprite "
                    + i
                    + ": "
                    + sprites[i].name
                    + ", parent: "
                    + sprites[i].transform.parent.name
            );
        }
        selectAction = InputSystem.actions.FindAction("Jump");

        this.parentState = parentState;
        this.hiddenIndices = hiddenIndices;
        // elapsed = 0.0f;
        // index = 0;
        // UpdateSprites();

        for (int i = 0; i < sprites.Length; i++)
        {
            SpriteGridCell sprite = sprites[i];
            if (hiddenIndices.Contains(i))
            {
                sprite.gameObject.SetActive(false);
            }
            else
            {
                sprite.gameObject.SetActive(true);
            }
        }

        SetButtonText();
    }

    public void SetButtonText(string text = "")
    {
        if (sprites[LAST_CELL_INDEX].TryGetComponent<SpriteGridCell>(out var lastCell))
        {
            lastCell.RenderButton(text);
        }
        else
        {
            Debug.LogError("Last cell does not have a SpriteGridCell component");
        }
    }

    public void RenderAllEmpty()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            SpriteGridCell sprite = sprites[i];
            sprite.RenderEmpty();
        }
    }

    // private void UpdateSprites()
    // {
    //     if (sprites == null)
    //     {
    //         return;
    //     }

    //     for (int i = 0; i < sprites.Length; i++)
    //     {
    //         SpriteGridCell sprite = sprites[i];
    //         if (i == index)
    //         {
    //             sprite.backgroundRenderer.color = Color.red;
    //         }
    //         else
    //         {
    //             sprite.backgroundRenderer.color = Color.white;
    //         }
    //     }
    // }

    // void Update()
    // {
    //     if (selectAction.WasPressedThisFrame() && parentState != null)
    //     {
    //         parentState.HandleButtonSelect(index);
    //         return;
    //     }

    //     elapsed += Time.deltaTime;
    //     if (elapsed >= delay)
    //     {
    //         elapsed = 0.0f;

    //         // Skip hidden indices
    //         do
    //         {
    //             index = (index + 1) % sprites.Length;
    //         } while (hiddenIndices.Contains(index));
    //     }

    //     UpdateSprites();
    // }
}
