using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Dialogue Window References")]
    public TMP_Text dialogueText;
    public RectTransform dialogueImage;
    public float dialogueWindowScaleSpeed = 5f;
    public float hintStringWindowMaxScale = 400;

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

    private void Update()
    {
        if (shouldSetHintstring)
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
