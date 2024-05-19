using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float movementSpeed = 1f;

    private Vector2 input;
    private Vector2 previousInput; // we add this to also fix a small flickering issue when the rotation was being applied every frame. We update it only when changed

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputActions playerInputActions;
    

    private int isWalkingHash;

    private void Awake()
    {
        playerInputActions = new();
        playerInputActions.Player.Enable();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("IsWalking");
    }

    private void Update()
    {
        input = playerInputActions.Player.Movement.ReadValue<Vector2>();
        
        HandleRotation(input);
        HandleAnimations();
        
        previousInput = input;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = input * movementSpeed;
    }

    private void HandleRotation(Vector2 input)
    {
        if (input != previousInput)
        {
            if (input.x > 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else if (input.x < 0) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void HandleAnimations()
    {
        bool isWalking = input.magnitude > 0.1f;
        animator.SetBool(isWalkingHash, isWalking);
    }
}
