public class AnimalUpgradeMenuItem : UpgradeMenuItem
{
    public new string Description
    {
        get
        {
            if (UpgradeLevel == 0)
            {
                return "Convert this plot to an animal pen, allowing you to raise animals instead of crops.";
            }

            if (UpgradeLevel == 1)
            {
                return "Upgrade the animal pen to increase the coins earned by one and make animals grow 50% faster.";
            }

            return "This upgrade is fully maxed out.";
        }
    }

    public override void ApplyUpgrade(PlotItem plot)
    {
        base.ApplyUpgrade(plot);

        if (UpgradeLevel == 1)
        {
            plot.areAnimalsAllowed = true;
            return;
        }

        if (UpgradeLevel == 2)
        {
            plot.bonusCoins = 1f;
            plot.growthRateMultiplier = 1.5f;
            return;
        }
    }
}
