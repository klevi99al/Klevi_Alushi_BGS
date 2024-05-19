using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
    [Header("Dialogue Window References")]
    public TMP_Text dialogueText;
    public RectTransform dialogueImage;

    [Header("Screen Transition References")]
    public Image screenTransitionImage;
    public bool shouldDoScreenTransition = false;
    private float currentAlpha = 0f;
    private float desiredAlpha = 1f;
    private bool isTransitioningIn = false;
    private bool isTransitioningOut = false;
    public bool transitionDone = false;
    private float fadeInDuration = 0.5f;
    private float fadeOutDuration = 0.5f;
    private float duration;
    private float delayTimer = 0f;
    private bool delayFinished = false;
    private bool fadeInFinished = false;

    [Header("UI and Cursor")]
    [SerializeField] private Texture2D activeCursor;
    [SerializeField] private TMP_Text playerMoneyText;
    public LevelManager levelManager;

    [Header("Player Inventory")]
    [SerializeField] private Transform inventorySlots;

    public static HUD Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdatePlayerMoneyHUD(float money)
    {
        if(money < 0f)
        {
            money = 0f;
        }

        playerMoneyText.text = money.ToString();
    }

    public void SetCursor(bool activeObject = false)
    {
        Cursor.SetCursor(activeObject == false ? null : activeCursor, new(activeCursor.width / 2, activeCursor.height / 2), CursorMode.Auto);
    }

    private void Update()
    {
        if (shouldDoScreenTransition && !transitionDone)
        {
            DoScreenTransition();
        }
    }

    private void DoScreenTransition()
    {
        if (!fadeInFinished)
        {
            transitionDone = false;

            if (!isTransitioningIn && !isTransitioningOut)
            {
                isTransitioningIn = true;
                desiredAlpha = 1.0f;
            }

            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, Time.deltaTime / fadeInDuration);
            Color color = screenTransitionImage.color;
            color.a = currentAlpha;
            screenTransitionImage.color = color;

            if (currentAlpha == desiredAlpha)
            {
                fadeInFinished = true;
            }
        }
        else if (!delayFinished)
        {
            delayTimer += Time.deltaTime;

            if (delayTimer >= duration)
            {
                delayFinished = true;
                delayTimer = 0f;

                isTransitioningOut = true;
                desiredAlpha = 0.0f;
            }
        }
        else
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, Time.deltaTime / fadeOutDuration);
            Color color = screenTransitionImage.color;
            color.a = currentAlpha;
            screenTransitionImage.color = color;

            if (currentAlpha == desiredAlpha)
            {
                ResetScreenTransitionVariables();
            }
        }
    }

    private void ResetScreenTransitionVariables()
    {
        currentAlpha = 0f;
        desiredAlpha = 1f;
        isTransitioningIn = false;
        isTransitioningOut = false;
        transitionDone = false;
        fadeInFinished = false;
        delayTimer = 0f;
        delayFinished = false;
        shouldDoScreenTransition = false;
        screenTransitionImage.gameObject.SetActive(false);
    }

    public void SetPlayerItems()
    {
        PlayerInventory playerInventory = levelManager.playerInventory;
        SpawnItems(playerInventory.hoodies, 0);
        SpawnItems(playerInventory.torsos, 1);
        SpawnItems(playerInventory.boots, 2);
    }

    private void SpawnItems(List<Item> items, int index)
    {
        for(int i = 0; i < items.Count; i++)
        {
            Image image = inventorySlots.transform.GetChild(index).GetChild(i).GetChild(0).GetComponent<Image>();
            image.GetComponentInParent<EquipItem>().item = items[i];
            image.color = Color.white;
            image.sprite = items[i].itemIcon;
        }
    }


    public void MakeScreenTransition(float waitTime)
    {
        if (!shouldDoScreenTransition)
        {
            duration = waitTime;
            transitionDone = false;
            shouldDoScreenTransition = true;
            desiredAlpha = 1;
            screenTransitionImage.gameObject.SetActive(true);
        }
    }
}
