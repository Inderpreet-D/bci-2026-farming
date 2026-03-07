using UnityEngine;

public class PlantMenuItem
{
    public string IconName { get; set; }

    public string[] GrowthStageIconNames { get; set; } = new string[0];
    public float TimeToGrow { get; set; }
    public int Yield { get; set; }
    public float PurchasePrice { get; set; }
    public float SellPrice { get; set; }
    public bool IsAnimal { get; set; }

    public PlantMenuItem Clone()
    {
        return new PlantMenuItem
        {
            IconName = (string)IconName.Clone(),
            TimeToGrow = TimeToGrow,
            Yield = Yield,
            PurchasePrice = PurchasePrice,
            SellPrice = SellPrice,
            IsAnimal = IsAnimal,
            GrowthStageIconNames = (string[])GrowthStageIconNames.Clone(),
        };
    }
}
