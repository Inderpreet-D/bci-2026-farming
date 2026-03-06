public class FarmUpgradeMenuItem : UpgradeMenuItem
{
    public new string Description
    {
        get
        {
            if (UpgradeLevel == 0)
            {
                return "Upgrade this plot to increase the coins earned and improve yield.";
            }

            if (UpgradeLevel == 1)
            {
                return "Upgrade this plot to make crops grow 50% faster.";
            }

            return "This upgrade is fully maxed out.";
        }
    }

    public override void ApplyUpgrade(PlotItem plot)
    {
        base.ApplyUpgrade(plot);

        if (UpgradeLevel == 1)
        {
            plot.bonusCoins = 1f;
            plot.bonusYield = 1f;
            return;
        }

        if (UpgradeLevel == 2)
        {
            plot.growthRateMultiplier = 1.5f;
            return;
        }
    }
}
