using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Items")]
    public List<Item> boots = new();
    public List<Item> torsos = new();
    public List<Item> legs = new(); // we need to keep track only the left leg, or even right, but it has to be only one of them the same for all

    [Header("Transforms")]
    public Transform hoodiesContainer;
    public Transform torsosContainer;
    public Transform legsContainer;
    public LevelManager levelManager;
    public GameObject itemCard;

    public void InstantiateItemCards()
    {
        InstantiateItemCardsForType(boots, hoodiesContainer);
        InstantiateItemCardsForType(torsos, torsosContainer);
        InstantiateItemCardsForType(legs, legsContainer);
    }

    private void InstantiateItemCardsForType(List<Item> items, Transform container)
    {
        foreach (Item item in items)
        {
            GameObject itemCardInstance = Instantiate(itemCard, container);
        }
    }



}
