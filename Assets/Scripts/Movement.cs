using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Set interpolation to smooth out movement
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Create movement vector
        Vector2 moveInput = new Vector2(moveX, moveY);
        moveVelocity = moveInput.normalized * moveSpeed;

        // Determine if the character is moving
        bool isMoving = moveInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            // Update the animator with the movement direction
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }
        else
        {
            // Optionally, reset the animation parameters when no input is detected
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
