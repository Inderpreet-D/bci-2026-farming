using TMPro;
using UnityEngine;

public class SpriteGridCell : MonoBehaviour
{
    public SpriteRenderer borderRenderer;
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer shopIconRenderer;
    public SpriteRenderer centerIconRenderer;
    public TextMeshProUGUI shopText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI debugText;

    private void HideAll()
    {
        borderRenderer.gameObject.SetActive(false);
        backgroundRenderer.gameObject.SetActive(false);
        shopIconRenderer.gameObject.SetActive(false);
        centerIconRenderer.gameObject.SetActive(false);
        shopText.gameObject.SetActive(false);
        buttonText.gameObject.SetActive(false);
        debugText.gameObject.SetActive(false);
    }

    public void RenderButton(string text = "")
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        buttonText.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("button");

        buttonText.text = text;
    }

    public void RenderPlantMenuItem(PlantMenuItem item)
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(true);
        shopText.gameObject.SetActive(true);

        if (item.Sprite == null)
        {
            item.Sprite = Resources.Load<Sprite>(item.IconName);
        }

        shopIconRenderer.sprite = item.Sprite;

        backgroundRenderer.sprite = item.IsAnimal
            ? Resources.Load<Sprite>("animal_bg")
            : Resources.Load<Sprite>("plant_bg");

        string itemText =
            $"{item.Name}\n{item.Description}\nBuy for ${Mathf.Floor(item.PurchasePrice)}\nTakes {Mathf.Floor(item.TimeToGrow)} seconds to grow\nYields {item.Yield} {item.YieldUnit}\nSells for ${Mathf.Floor(item.SellPrice)} each";
        shopText.text = itemText;
    }

    public void RenderEmpty()
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("empty");
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

        backgroundRenderer.sprite = Resources.Load<Sprite>("empty");

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
        centerIconRenderer.gameObject.SetActive(true);
        debugText.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("empty");

        if (plot.Being.Sprite == null)
        {
            plot.Being.Sprite = Resources.Load<Sprite>(plot.Being.IconName);
        }
        centerIconRenderer.sprite = plot.Being.Sprite;
        if (plot.Being.IsAnimal)
        {
            backgroundRenderer.sprite = Resources.Load<Sprite>("animal_bg");
            centerIconRenderer.color = Color.purple;
        }
        else
        {
            backgroundRenderer.sprite = Resources.Load<Sprite>("plant_bg");
            centerIconRenderer.color = Color.white;
        }

        debugText.text =
            $"{plot.Being.Name}\nTime: {Mathf.Floor(plot.elapsedTime)}/{Mathf.Ceil(plot.Being.TimeToGrow)}s\n{plot.elapsedTime / plot.Being.TimeToGrow * 100f:0.##}%";

        RenderUpgradeBorder(plot.Upgrade);
    }
}
