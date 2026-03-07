using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteGridCell : MonoBehaviour
{
    public int CellIndex;
    public MainController mainController;
    public SpriteRenderer borderRenderer;
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer shopIconRenderer;
    public SpriteRenderer centerIconRenderer;
    public SpriteRenderer animalIconRenderer;
    public GameObject shopCanvas;
    public TextMeshProUGUI shopText;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI buttonText;

    private void HideAll()
    {
        borderRenderer.gameObject.SetActive(false);
        backgroundRenderer.gameObject.SetActive(false);
        shopIconRenderer.gameObject.SetActive(false);
        centerIconRenderer.gameObject.SetActive(false);
        animalIconRenderer.gameObject.SetActive(false);
        shopCanvas.SetActive(false);
        shopText.gameObject.SetActive(false);
        upgradeText.gameObject.SetActive(false);
        buttonText.gameObject.SetActive(false);
    }

    public void RenderButton(string text = "")
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        buttonText.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/button");

        buttonText.text = text;
    }

    public void RenderPlantMenuItem(PlantMenuItem item)
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(true);
        shopCanvas.SetActive(true);
        shopText.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/empty");

        shopIconRenderer.sprite = Resources.Load<Sprite>(item.IconName);

        string itemText =
            $"Buy\n{item.PurchasePrice}\n\nSell\n{item.SellPrice}\n\n{item.TimeToGrow}";
        shopText.text = itemText;
    }

    public void RenderEmpty()
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/empty");
    }

    private void RenderUpgradeBorder(UpgradeMenuItem upgrade)
    {
        if (upgrade == null)
        {
            return;
        }

        borderRenderer.gameObject.SetActive(true);

        if (upgrade.UpgradeLevel == 0)
        {
            // Bronze color: RGB(205, 127, 50)
            borderRenderer.color = new Color(205f / 255f, 127f / 255f, 50f / 255f);
        }
        else if (upgrade.UpgradeLevel == 1)
        {
            borderRenderer.color = Color.silver;
        }
        else if (upgrade.UpgradeLevel == UpgradeMenuItem.MAX_UPGRADE_LEVEL)
        {
            borderRenderer.color = Color.gold;
        }
    }

    private void RenderEmptyPlot(PlotItem plot)
    {
        HideAll();

        borderRenderer.gameObject.SetActive(true);
        backgroundRenderer.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/plot");

        RenderUpgradeBorder(plot.Upgrade);
    }

    public void RenderPlotItem(PlotItem plot)
    {
        HideAll();

        if (plot.IsEmpty())
        {
            RenderEmptyPlot(plot);
            return;
        }

        backgroundRenderer.gameObject.SetActive(true);

        if (plot.areAnimalsAllowed)
        {
        animalIconRenderer.gameObject.SetActive(true);
            
        animalIconRenderer.sprite = Resources.Load<Sprite>(plot.Being.IconName);
        } else
        {
            
        centerIconRenderer.gameObject.SetActive(true);
        centerIconRenderer.sprite = Resources.Load<Sprite>(plot.Being.IconName);
        }

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/plot");


        
        RenderUpgradeBorder(plot.Upgrade);
    }

    public void RenderUpgradeItem(UpgradeMenuItem upgrade)
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        upgradeText.gameObject.SetActive(true);

        string text;
        if (upgrade.UpgradeLevel >= UpgradeMenuItem.MAX_UPGRADE_LEVEL)
        {
            text =
                $"{upgrade.GetDescription()}\nUpgrade maxed out\nCurrent level: {upgrade.UpgradeLevel}/{UpgradeMenuItem.MAX_UPGRADE_LEVEL}";
        }
        else
        {
            text =
                $"{upgrade.GetDescription()}\nBuy for ${Mathf.Floor(upgrade.UpgradeCosts[upgrade.UpgradeLevel])}\nCurrent level: {upgrade.UpgradeLevel}/{UpgradeMenuItem.MAX_UPGRADE_LEVEL}";
        }
        upgradeText.text = text;

        RenderUpgradeBorder(upgrade);

        backgroundRenderer.sprite = Resources.Load<Sprite>("sprites/general/empty");
    }

    void OnMouseDown()
    {
        mainController.stateMachine.currentState.HandleButtonSelect(CellIndex);
    }
}
