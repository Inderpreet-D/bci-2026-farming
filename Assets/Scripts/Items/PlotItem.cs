using UnityEngine;

public class PlotItem
{
    public PlantMenuItem Being { get; set; }
    public UpgradeMenuItem Upgrade { get; set; }
    public float growthRateMultiplier = 1f;
    public float bonusCoins = 0f;
    public float bonusYield = 0f;
    public bool areAnimalsAllowed = false;
    public float elapsedTime;

    public void Clear()
    {
        Being = null;
    }

    public void PlantBeing(PlantMenuItem being)
    {
        Being = being.Clone();
        elapsedTime = 0f;
    }

    public float Harvest(State state)
    {
        float totalYield = Being.Yield + bonusYield;
        float gainedCoins = (Being.SellPrice + bonusCoins) * totalYield;

        state.mainController.Coins += gainedCoins;
        state.mainController.Score += gainedCoins;

        Clear();

        return totalYield;
    }

    public bool IsEmpty()
    {
        return Being == null;
    }

    public void ApplyUpgrade()
    {
        Upgrade.ApplyUpgrade(this);
    }

    public bool IsFullyGrown()
    {
        if (Being == null)
        {
            return false;
        }

        float growthTime = Being.TimeToGrow;
        return elapsedTime >= growthTime;
    }

    public void Tick()
    {
        if (Being == null)
        {
            return;
        }

        if (IsFullyGrown())
        {
            return;
        }

        elapsedTime += Time.deltaTime * growthRateMultiplier;
    }

    public float GetGrowthPercentage()
    {
        if (Being == null)
        {
            return 0f;
        }

        return Mathf.Clamp01(elapsedTime / Being.TimeToGrow);
    }
}
