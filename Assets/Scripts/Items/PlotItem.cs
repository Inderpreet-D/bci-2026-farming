using UnityEngine;

public class PlotItem
{
    private string name;
    private string description;
    private string iconName;
    private float timeToGrow;
    private int yield;
    private string yieldUnit;
    private float purchasePrice;
    private float sellPrice;
    private bool isAnimal;
    private Sprite sprite;

    public PlotItem(
        string name,
        string description,
        string iconName,
        float timeToGrow,
        int yield,
        string yieldUnit,
        float purchasePrice,
        float sellPrice,
        bool isAnimal
    )
    {
        this.name = name;
        this.description = description;
        this.iconName = iconName;
        this.timeToGrow = timeToGrow;
        this.yield = yield;
        this.yieldUnit = yieldUnit;
        this.purchasePrice = purchasePrice;
        this.sellPrice = sellPrice;
        this.isAnimal = isAnimal;
        this.sprite = Resources.Load<Sprite>("Sprites/" + iconName + ".png");
    }

    public void UpdateSpriteGridCell(GameObject gridCell)
    {
        SpriteRenderer spriteRenderer = gridCell.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
