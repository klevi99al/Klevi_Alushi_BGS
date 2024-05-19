using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private string text;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void MouseClick()
    {
        HUD.Instance.dialogueImage.gameObject.SetActive(true);
        HUD.Instance.dialogueText.text = text;
        HUD.Instance.SetCursor();
    }

    public void EnableOrDisableInteraction(bool state)
    {
        boxCollider.enabled = state;
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
