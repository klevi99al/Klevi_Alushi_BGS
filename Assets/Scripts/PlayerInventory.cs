using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int playerMoney = 1000;
    public int maxItemsNumber = 5; // added this so i can limit the items according to the UI to avoid buying infinite items

    public List<Item> hoodies = new();
    public List<Item> torsos = new();
    public List<Item> boots = new();
}
