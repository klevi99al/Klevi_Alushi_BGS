using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sound;
    [SerializeField] private LevelManager levelManager;

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
        if(source != null && sound != null)
        {
            source.PlayOneShot(sound);
        }

        HUD.Instance.MakeScreenTransition(2);
        levelManager.player.GetComponent<PlayerUtils>().TeleportPlayer(destination.position, 2);
        levelManager.exitShop.SetActive(true);
    }
}
