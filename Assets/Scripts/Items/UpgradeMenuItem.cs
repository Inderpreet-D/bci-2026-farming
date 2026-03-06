public abstract class UpgradeMenuItem
{
    public const int MAX_UPGRADE_LEVEL = 2;

    public string Description
    {
        get => "Not implemented for this upgrade.";
    }
    public float[] UpgradeCosts { get; set; } = new float[MAX_UPGRADE_LEVEL];
    public int UpgradeLevel { get; set; } = 0;

    public virtual void ApplyUpgrade(PlotItem plot)
    {
        if (UpgradeLevel < MAX_UPGRADE_LEVEL)
        {
            UpgradeLevel++;
        }
    }

    public bool IsMaxLevel()
    {
        return UpgradeLevel >= MAX_UPGRADE_LEVEL;
    }

    public float GetCurrentUpgradeCost()
    {
        if (UpgradeLevel < MAX_UPGRADE_LEVEL)
        {
            return UpgradeCosts[UpgradeLevel];
        }
        else
        {
            return -1f; // No more upgrades available
        }
    }

    public abstract string GetDescription();
}
