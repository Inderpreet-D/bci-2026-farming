using UnityEngine;

public class PlotItem
{
    public PlantMenuItem Plant { get; set; }
    public UpgradeMenuItem Upgrade { get; set; }
    public float growthRateMultiplier = 1f;
    public float bonusCoins = 0f;
    public float bonusYield = 0f;
    public bool areAnimalsAllowed = false;
    private float elapsedTime;

    public void ClearPlot()
    {
        Plant = null;
    }

    public void PlantSeed(PlantMenuItem plant)
    {
        Plant = plant.Clone();
        elapsedTime = 0f;
    }

    public void HarvestPlot()
    {
        // TODO Update coins based on plant yield and upgrades
        ClearPlot();
    }

    public bool IsEmpty()
    {
        return Plant == null;
    }

    public void ApplyUpgrade()
    {
        Upgrade.ApplyUpgrade(this);
    }

    public bool IsFullyGrown()
    {
        if (Plant == null)
        {
            return false;
        }

        float growthTime = Plant.TimeToGrow;

        return elapsedTime >= Plant.TimeToGrow;
    }

    public void Tick()
    {
        if (Plant == null)
        {
            return;
        }

        if (IsFullyGrown())
        {
            return;
        }

        elapsedTime += Time.deltaTime * growthRateMultiplier;
    }
}
