using UnityEngine;

public class MainController : MonoBehaviour
{
    public State trainingController;
    public State tutorialController;
    public State gameController;
    public State upgradeMenuController;
    public State plantMenuController;

    StateMachine stateMachine;
    public PlotItem[] PlotItems { get; private set; }
    public int Coins { get; set; } = 100;

    void Start()
    {
        stateMachine = new StateMachine(this);
        PlotItems = new PlotItem[]
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
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
    }
}
