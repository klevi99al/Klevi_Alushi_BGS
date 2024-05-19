using UnityEngine;

public class PlayerUtils : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    private bool shouldTeleport = false;
    private bool hasTeleported = false;

    [Header("Body Parts")]
    public SpriteRenderer hoodie;
    public SpriteRenderer torso;
    public SpriteRenderer legRight;
    public SpriteRenderer legLeft;

    private Vector2 teleportPosition;
    private float waitTime;
    private float teleportTimer;

    private readonly int maxPlayerMoney = 10000;

    private void Update()
    {
        if (shouldTeleport && !hasTeleported)
        {
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= waitTime)
            {
                Teleport();
            }
        }
    }

    public void TeleportPlayer(Vector2 position, float waitTime)
    {
        shouldTeleport = true;
        teleportPosition = position;
        this.waitTime = waitTime;
    }

    public void GiveOrTakeMoney(int amount)
    {
        inventory.playerMoney += amount;
        if(inventory.playerMoney > maxPlayerMoney)
        {
            inventory.playerMoney = maxPlayerMoney;
        }
        HUD.Instance.UpdatePlayerMoneyHUD(inventory.playerMoney);
    }

    private void Teleport()
    {
        transform.position = teleportPosition;
        shouldTeleport = false;
        hasTeleported = false;
        teleportTimer = 0f;
    }
}
