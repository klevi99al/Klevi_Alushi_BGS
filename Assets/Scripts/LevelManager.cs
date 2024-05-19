using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject exitShop;

    public Transform initialPlayerPosition;
    public PlayerInventory playerInventory;
    [Header("Audio References")]
    public Toggle backgroundMusicToggle;
    public AudioSource backgroundMusicSource;

    private void Start()
    {
        SetBackgroundSound();
        player.GetComponent<PlayerUtils>().TeleportPlayer(initialPlayerPosition.position, 0);
        playerInventory = player.GetComponent<PlayerInventory>();
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

    public void TryPurchaseShopItem(Item item)
    {
        if(playerInventory.playerMoney >= item.itemPrice)
        {
            switch(item.itemType)
            {
                case ItemType.Boots:
                    if(!playerInventory.boots.Contains(item) && playerInventory.boots.Count < playerInventory.maxItemsNumber)
                    {
                        playerInventory.playerMoney -= item.itemPrice;
                        playerInventory.boots.Add(item);
                    }
                    break;
                case ItemType.Torso:
                    if (!playerInventory.torsos.Contains(item) && playerInventory.torsos.Count < playerInventory.maxItemsNumber)
                    {
                        playerInventory.playerMoney -= item.itemPrice;
                        playerInventory.torsos.Add(item);
                    }
                    break;
                case ItemType.Hood:
                    if (!playerInventory.hoodies.Contains(item) && playerInventory.hoodies.Count < playerInventory.maxItemsNumber)
                    {
                        playerInventory.playerMoney -= item.itemPrice;
                        playerInventory.hoodies.Add(item);
                    }
                    break;
                default: break;
            }

            HUD.Instance.UpdatePlayerMoneyHUD(playerInventory.playerMoney);
        }
    }

    public void EnableOrDisablePlayerMovement(bool state)
    {
        player.GetComponent<PlayerMovement>().enabled = state;
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
