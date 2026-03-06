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

    public PlantMenuItem Clone()
    {
        return new PlantMenuItem
        {
            Name = (string)this.Name.Clone(),
            Description = (string)this.Description.Clone(),
            IconName = (string)this.IconName.Clone(),
            TimeToGrow = this.TimeToGrow,
            Yield = this.Yield,
            YieldUnit = (string)this.YieldUnit.Clone(),
            PurchasePrice = this.PurchasePrice,
            SellPrice = this.SellPrice,
            IsAnimal = this.IsAnimal,
        };
    }
}
