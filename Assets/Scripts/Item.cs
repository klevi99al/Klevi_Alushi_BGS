using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemIndex;
    public int itemPrice;
    public Sprite itemIcon;
    public ItemType itemType;
}

public enum ItemType
{
    Hood,
    Torso,
    Boots
}
