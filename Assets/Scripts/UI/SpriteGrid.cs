using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteGrid : MonoBehaviour
{
    public float delay = 0.3f;
    public SpriteRenderer[] sprites;
    private float elapsed = 0.0f;
    private int index = 0;
    private State parentState;
    private InputAction selectAction;

    public void Setup(State parentState, List<int> hiddenIndices)
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        this.parentState = parentState;
        elapsed = 0.0f;
        index = 0;
        UpdateSprites();

        for (int i = 0; i < sprites.Length; i++)
        {
            SpriteRenderer sprite = sprites[i];
            if (hiddenIndices.Contains(i))
            {
                sprite.gameObject.SetActive(false);
            }
            else
            {
                sprite.gameObject.SetActive(true);
            }
        }
    }

    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
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
            SpriteRenderer sprite = sprites[i];
            if (i == index)
            {
                sprite.color = Color.red;
            }
            else
            {
                sprite.color = Color.white;
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
            index = (index + 1) % sprites.Length;
        }

        UpdateSprites();
    }
}
