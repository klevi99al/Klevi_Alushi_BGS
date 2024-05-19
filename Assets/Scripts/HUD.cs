using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Threading;

public class HUD : MonoBehaviour
{
    [Header("Dialogue Window References")]
    public TMP_Text dialogueText;
    public RectTransform dialogueImage;
    public float dialogueWindowScaleSpeed = 5f;
    public float hintStringWindowMaxScale = 400;

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

    public static HUD Instance;
    public bool shouldSetHintstring = false;

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
        if (shouldSetHintstring)
        {
            DoDialogueWindowTransition();
        }

        if (shouldDoScreenTransition && !transitionDone)
        {
            DoScreenTransition();
        }
    }

    private void DoDialogueWindowTransition()
    {
        Vector2 finalSizeDelta = dialogueImage.sizeDelta + new Vector2(0, hintStringWindowMaxScale);

        dialogueImage.sizeDelta = Vector2.MoveTowards(dialogueImage.sizeDelta, finalSizeDelta, dialogueWindowScaleSpeed * Time.deltaTime);

        if (dialogueImage.sizeDelta.y >= hintStringWindowMaxScale)
        {
            dialogueImage.sizeDelta = new Vector2(dialogueImage.sizeDelta.x, hintStringWindowMaxScale);
            dialogueText.gameObject.SetActive(true);
            shouldSetHintstring = false;
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

    public void SetHintString(string hint)
    {
        dialogueText.text = hint;
        shouldSetHintstring = true;
    }

    public void CloseHintString()
    {
        dialogueText.text = string.Empty;
        dialogueText.gameObject.SetActive(false);
        shouldSetHintstring = false;
        dialogueImage.sizeDelta = new Vector2(dialogueImage.sizeDelta.x, 0);
    }
}
