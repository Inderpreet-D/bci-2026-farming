using UnityEngine;

public class MainController : MonoBehaviour
{
    public const int UNSELECTED_PLOT_INDEX = -1;

    public State trainingController;
    public State gameController;
    public State upgradeMenuController;
    public State plantMenuController;

    StateMachine stateMachine;
    public PlotItem[] PlotItems { get; private set; }
    public float Coins { get; set; } = 100.0f;
    public int LastSelectedPlotIndex { get; set; } = UNSELECTED_PLOT_INDEX;

    void Start()
    {
        stateMachine = new StateMachine(this);
        PlotItems = new PlotItem[SpriteGrid.NUM_CELLS - 1]
        {
            // Regular farm plots
            new()
            {
                Upgrade = new FarmUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 5f, 10f },
                },
            },
            new()
            {
                Upgrade = new FarmUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 5f, 10f },
                },
            },
            new()
            {
                Upgrade = new FarmUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 5f, 10f },
                },
            },
            // Animal pens
            new()
            {
                Upgrade = new AnimalUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 10f, 20f },
                },
            },
            new()
            {
                Upgrade = new AnimalUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 10f, 20f },
                },
            },
            new()
            {
                Upgrade = new AnimalUpgradeMenuItem
                {
                    UpgradeCosts = new float[UpgradeMenuItem.MAX_UPGRADE_LEVEL] { 10f, 20f },
                },
            },
        };
    }

    void Update()
    {
        stateMachine?.Update();
    }

    public bool PlantBeing(PlantMenuItem being)
    {
        if (LastSelectedPlotIndex == UNSELECTED_PLOT_INDEX)
        {
            return false;
        }

        PlotItem selectedPlot = PlotItems[LastSelectedPlotIndex];
        if (!selectedPlot.IsEmpty())
        {
            return false;
        }

        if (Coins < being.PurchasePrice)
        {
            return false;
        }

        Coins -= being.PurchasePrice;
        PlotItems[LastSelectedPlotIndex].PlantBeing(being);
        LastSelectedPlotIndex = UNSELECTED_PLOT_INDEX;

        return true;
    }

    public bool ApplyUpgrade(int index)
    {
        PlotItem selectedPlot = PlotItems[index];

        if (selectedPlot.Upgrade.IsMaxLevel())
        {
            return false;
        }

        float upgradeCost = selectedPlot.Upgrade.GetCurrentUpgradeCost();
        if (upgradeCost < 0f)
        {
            return false;
        }

        if (Coins < upgradeCost)
        {
            return false;
        }

        Coins -= upgradeCost;
        selectedPlot.ApplyUpgrade();

        return true;
    }
}
