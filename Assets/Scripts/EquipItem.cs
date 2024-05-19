using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public Item item;
    private GameObject owner;

    private void Start()
    {
        owner = HUD.Instance.levelManager.player;
    }

    public void EquipItemToPlayer()
    {
        if (item == null) return;
        PlayerUtils playerUtils = owner.GetComponent<PlayerUtils>();
        switch (item.itemType)
        {
            case ItemType.Hood: playerUtils.hoodie.sprite = item.itemIcon; break;
            case ItemType.Torso: playerUtils.torso.sprite = item.itemIcon; break;
            case ItemType.Boots: 
                playerUtils.legLeft.sprite = item.itemIcon;
                playerUtils.legRight.sprite = item.itemIcon;
                break;
            default: break;
        }
    }
}
