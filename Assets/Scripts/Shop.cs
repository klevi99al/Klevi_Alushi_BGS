using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Items")]
    public List<Sprite> boots = new();
    public List<Sprite> torsos = new();
    public List<Sprite> legs = new(); // we need to keep track only the left leg, or even right, but it has to be only one of them the same for all
}
