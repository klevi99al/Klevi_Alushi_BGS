using UnityEngine;

public class PurchaseItem : MonoBehaviour
{
    public Item item;
    public LevelManager levelManager;

    public void PurchaseTheItem()
    {
        levelManager.TryPurchaseShopItem(item);
    }
}
