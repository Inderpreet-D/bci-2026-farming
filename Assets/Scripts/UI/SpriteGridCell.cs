using TMPro;
using UnityEngine;

public class SpriteGridCell : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer shopIconRenderer;
    public SpriteRenderer centerIconRenderer;
    public TextMeshProUGUI shopText;
    public TextMeshProUGUI debugText;

    private void HideAll()
    {
        backgroundRenderer.gameObject.SetActive(false);
        shopIconRenderer.gameObject.SetActive(false);
        centerIconRenderer.gameObject.SetActive(false);
        shopText.gameObject.SetActive(false);
        debugText.gameObject.SetActive(false);
    }

    public void RenderButton()
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("button");
    }

    public void RenderPlantMenuItem(PlantMenuItem item)
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(true);
        shopText.gameObject.SetActive(true);

        if (item.sprite == null)
        {
            item.sprite = Resources.Load<Sprite>(item.iconName);
        }

        shopIconRenderer.sprite = item.sprite;

        backgroundRenderer.sprite = item.isAnimal
            ? Resources.Load<Sprite>("animal_bg")
            : Resources.Load<Sprite>("plant_bg");

        string itemText =
            $"{item.name}\n{item.description}\nBuy for {Mathf.Floor(item.purchasePrice)}\nTakes {Mathf.Floor(item.timeToGrow)} seconds to grow\nYields {item.yield} {item.yieldUnit}\nSells for {Mathf.Floor(item.sellPrice)} each";
        shopText.text = itemText;
    }

    public void RenderEmpty()
    {
        HideAll();

        backgroundRenderer.gameObject.SetActive(true);

        backgroundRenderer.sprite = Resources.Load<Sprite>("empty");
    }
}
