using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteGrid : MonoBehaviour
{
    public float delay = 0.3f;
    public SpriteGridCell[] sprites;
    private float elapsed = 0.0f;
    private int index = 0;
    private State parentState;
    private InputAction selectAction;
    private List<int> hiddenIndices;

    public void Setup(State parentState, List<int> hiddenIndices)
    {
        sprites = GetComponentsInChildren<SpriteGridCell>(true);
        this.parentState = parentState;
        this.hiddenIndices = hiddenIndices;
        elapsed = 0.0f;
        index = 0;
        UpdateSprites();

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

        if (sprites[9].TryGetComponent<SpriteGridCell>(out var lastCell))
        {
            lastCell.RenderButton();
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

    void Start()
    {
        sprites = GetComponentsInChildren<SpriteGridCell>(true);
        selectAction = InputSystem.actions.FindAction("Jump");
    }

    private void UpdateSprites()
    {
        if (sprites == null)
        {
            return;
        }

        for (int i = 0; i < sprites.Length; i++)
        {
            SpriteGridCell sprite = sprites[i];
            if (i == index)
            {
                sprite.backgroundRenderer.color = Color.red;
            }
            else
            {
                sprite.backgroundRenderer.color = Color.white;
            }
        }
    }

    void Update()
    {
        if (selectAction.WasPressedThisFrame() && parentState != null)
        {
            parentState.HandleButtonSelect(index);
            return;
        }

        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = 0.0f;

            // Skip hidden indices
            do
            {
                index = (index + 1) % sprites.Length;
            } while (hiddenIndices.Contains(index));
        }

        UpdateSprites();
    }
}
