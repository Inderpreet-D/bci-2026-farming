using UnityEngine;

public class PlantMenuItem
{
    public string name { get; set; }
    public string description { get; set; }
    public string iconName { get; set; }
    public float timeToGrow { get; set; }
    public int yield { get; set; }
    public string yieldUnit { get; set; }
    public float purchasePrice { get; set; }
    public float sellPrice { get; set; }
    public bool isAnimal { get; set; }
    public Sprite sprite { get; set; }
}
