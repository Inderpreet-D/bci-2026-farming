using TMPro;
using UnityEngine;

public class SpriteGridCell : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer shopIconRenderer;
    public SpriteRenderer centerIconRenderer;
    public TextMeshProUGUI text;

    public void RenderButton()
    {
        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(false);
        centerIconRenderer.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

        backgroundRenderer.sprite = Resources.Load<Sprite>("button");
    }

    public void RenderPlantMenuItem(PlantMenuItem item)
    {
        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(true);
        centerIconRenderer.gameObject.SetActive(false);
        text.gameObject.SetActive(true);

        if (item.sprite == null)
        {
            item.sprite = Resources.Load<Sprite>(item.iconName);
        }

        backgroundRenderer.sprite = item.isAnimal
            ? Resources.Load<Sprite>("animal_bg")
            : Resources.Load<Sprite>("plant_bg");
        shopIconRenderer.sprite = item.sprite;

        string itemText =
            $"{item.name}\n{item.description}\nBuy for {Mathf.Floor(item.purchasePrice)}\nTakes {Mathf.Floor(item.timeToGrow)} seconds to grow\nYields {item.yield} {item.yieldUnit}\nSells for {Mathf.Floor(item.sellPrice)} each";
        text.text = itemText;
    }

    public void RenderEmpty()
    {
        backgroundRenderer.gameObject.SetActive(true);
        shopIconRenderer.gameObject.SetActive(false);
        centerIconRenderer.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

        backgroundRenderer.sprite = Resources.Load<Sprite>("empty");
    }
}
