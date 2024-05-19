using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool activated = false;
    [SerializeField] private GameObject destination;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sound;

    private void OnMouseEnter()
    {
        HUD.Instance.SetCursor(true);
    }

    private void OnMouseExit()
    {
        HUD.Instance.SetCursor();
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
    }
}
