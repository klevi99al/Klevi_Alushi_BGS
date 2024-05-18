using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private PlayerInputActions playerInputActions;
    private Vector2 input;
    private int isWalkingHash;

    private void Awake()
    {
        playerInputActions = new();
        playerInputActions.Player.Enable();
        isWalkingHash = Animator.StringToHash("IsWalking");
    }

    private void Update()
    {
        input = playerInputActions.Player.Movement.ReadValue<Vector2>();
        HandleRotation();
        HandleAnimations();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = input * movementSpeed;
    }

    private void HandleRotation()
    {
        if (input.x > 0) transform.eulerAngles = Vector2.zero;
        else if (input.x < 0) transform.eulerAngles = new(0, 180);
    }

    private void HandleAnimations()
    {
        bool isWalking = input.magnitude > 0.1f;
        animator.SetBool(isWalkingHash, isWalking);
    }
}
