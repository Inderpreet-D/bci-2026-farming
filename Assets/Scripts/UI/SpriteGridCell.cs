using TMPro;
using UnityEngine;

public class SpriteGridCell : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer shopIconRenderer;
    public SpriteRenderer centerIconRenderer;
    public TextMeshProUGUI shopText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI debugText;

    private void HideAll()
    {
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

    public void RenderPlotItem(PlotItem plot)
    {
        HideAll();

        if (plot.IsEmpty())
        {
            RenderEmpty();
            return;
        }

        backgroundRenderer.gameObject.SetActive(true);
        debugText.gameObject.SetActive(true);

        backgroundRenderer.sprite = plot.Being.IsAnimal
            ? Resources.Load<Sprite>("animal_bg")
            : Resources.Load<Sprite>("plant_bg");

        debugText.text =
            $"{plot.Being.Name}\nTime: {Mathf.Floor(plot.elapsedTime)}/{Mathf.Ceil(plot.Being.TimeToGrow)}s";
    }
}
