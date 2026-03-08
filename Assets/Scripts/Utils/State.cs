using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class State
{
    public MainController mainController;
    protected StateMachine stateMachine;
    public SpriteGrid spriteGrid;
    public bool IsActive { get; set; }

    public State(MainController mainController, StateMachine stateMachine)
    {
        this.mainController = mainController;
        this.stateMachine = stateMachine;
        spriteGrid = new SpriteGrid();
        IsActive = false;
    }

    public virtual void SetupSpriteGrid()
    {
        spriteGrid.Setup(this, new List<int> { });
    }

    public virtual void Enter(MainController mainController, StateMachine stateMachine)
    {
        IsActive = true;
        this.mainController = mainController;
        this.stateMachine = stateMachine;
        SetupSpriteGrid();
    }

    public virtual void Exit()
    {
        IsActive = false;
    }

    public virtual void Tick() { }

    public virtual void HandleButtonSelect(int index) { }
}
