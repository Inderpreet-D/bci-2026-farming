using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteGrid
{
    public const int NUM_CELLS = 7;
    public const int LAST_CELL_INDEX = NUM_CELLS - 1;
    public float delay = 0.3f;
    public SpriteGridCell[] sprites;

    public void Setup(State parentState, List<int> hiddenIndices)
    {
        sprites = parentState.mainController.GetAllSpriteGridCells();

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
}
