using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 1f;
    public float jumpForce = 0.4f;
    public float jumpCooldown = 0.1f;

    public bool puzzleActive = true;
    public bool isMoving = false;

    private float nextJumpTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame &&
            Time.time >= nextJumpTime)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            nextJumpTime = Time.time + jumpCooldown;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
        isMoving = true;
    }
}