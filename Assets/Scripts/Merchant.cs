using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private string text;

    public void MouseClick()
    {
        HUD.Instance.dialogueImage.gameObject.SetActive(true);
        HUD.Instance.dialogueText.text = text;
        HUD.Instance.SetCursor();
    }

    private void OnMouseEnter()
    {
        HUD.Instance.SetCursor(true);
    }

    private void OnMouseExit()
    {
        HUD.Instance.SetCursor();
    }

    private void OnMouseUp()
    {
        HUD.Instance.dialogueImage.gameObject.SetActive(true);
        HUD.Instance.dialogueText.text = text;
        HUD.Instance.SetCursor();
    }
}
