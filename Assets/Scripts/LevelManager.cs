using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject exitShop;

    public Transform initialPlayerPosition;

    [Header("Audio References")]
    public Toggle backgroundMusicToggle;
    public AudioSource backgroundMusicSource;

    private void Start()
    {
        SetBackgroundSound();
        player.GetComponent<PlayerUtils>().TeleportPlayer(initialPlayerPosition.position, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetBackgroundSound()
    {
        backgroundMusicSource.volume = backgroundMusicToggle.isOn ? 0.2f : 0f;
    }

    public void SendPlayerToVillage()
    {
        HUD.Instance.MakeScreenTransition(2);
        player.GetComponent<PlayerUtils>().TeleportPlayer(initialPlayerPosition.position, 2);
    }

    public void TryPurchaseShopItem(int itemPrice)
    {

    }

    public void TryGiveMoney(TMP_InputField text)
    {
        bool works = int.TryParse(text.text, out int number);

        if (works)
        {
            player.GetComponent<PlayerUtils>().GiveOrTakeMoney(number);
        }
        else
        {
            Debug.Log("Cannot Send Money LOL");
        }
    }
}
