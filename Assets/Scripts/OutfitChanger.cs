using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to Change")]
    public SpriteRenderer bodyPart;

    public List<Sprite> options = new();

    private int currentOption = 0;

    public void NextOpion()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.sprite = options[currentOption];
    }

    public void PrevOpion()
    {
        currentOption--;
        if(currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        bodyPart.sprite = options[currentOption];
    }
}
