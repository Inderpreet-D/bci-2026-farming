using UnityEngine;

public class PlantMenuItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconName { get; set; }
    public float TimeToGrow { get; set; }
    public int Yield { get; set; }
    public string YieldUnit { get; set; }
    public float PurchasePrice { get; set; }
    public float SellPrice { get; set; }
    public bool IsAnimal { get; set; }
    public Sprite Sprite { get; set; }
}
