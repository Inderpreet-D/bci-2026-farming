using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public SpriteGrid spriteGrid;

    protected MainController mainController;
    protected StateMachine stateMachine;

    public virtual void SetupSpriteGrid()
    {
        spriteGrid.Setup(this, new List<int> { });
    }

    public virtual void Enter(MainController mainController, StateMachine stateMachine)
    {
        gameObject.SetActive(true);
        this.mainController = mainController;
        this.stateMachine = stateMachine;
        SetupSpriteGrid();
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public virtual void Tick() { }

    public virtual void HandleButtonSelect(int index)
    {
        Debug.Log("Button pressed: " + index.ToString());
    }
}
