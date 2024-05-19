using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Items")]
    public List<Item> hoodies = new();
    public List<Item> torsos = new();
    public List<Item> boots = new(); // we need to keep track only the left leg, or even right, but it has to be only one of them the same for all

    private bool itemsSpawned = false;
    [SerializeField] private Merchant merchant;
    [Header("Transforms")]
    public Transform hoodiesContainer;
    public Transform torsosContainer;
    public Transform legsContainer;
    public LevelManager levelManager;
    public GameObject itemCard;

    public void InstantiateItemCards()
    {
        // Not good for shops that can add items in runtime as this will spawn them only once, but we're just testing stuff anyway
        if (!itemsSpawned)
        {
            itemsSpawned = true;
            InstantiateItemCardsForType(hoodies, hoodiesContainer);
            InstantiateItemCardsForType(torsos, torsosContainer);
            InstantiateItemCardsForType(boots, legsContainer);
        }
        levelManager.EnableOrDisablePlayerMovement(false);
        merchant.EnableOrDisableInteraction(false);
    }

    private void InstantiateItemCardsForType(List<Item> items, Transform container)
    {
        foreach (Item itemInstance in items)
        {
            GameObject item = Instantiate(itemCard, container);
            
            PurchaseItem purchase = item.GetComponent<PurchaseItem>();
            purchase.item = itemInstance;
            purchase.levelManager = levelManager;
            
            Image image = item.transform.GetChild(0).GetComponent<Image>();
            image.color = Color.white;
            image.sprite = itemInstance.itemIcon;

            item.GetComponentInChildren<TMP_Text>().text = "Buy: " + itemInstance.itemPrice.ToString();
        }
    }
}
