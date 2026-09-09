using UnityEngine;
using UnityEngine.InputSystem;


public class EventInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        // Get references to components
        rb = GetComponent<Rigidbody2D>();
    }

    // Reads player movement for the puzzle
    public void OnMove(InputAction.CallbackContext context)
    {
        // Read the Vector2 value from the input action
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Apply physics-safe movement movement
        rb.MovePosition(rb.position + moveInput* moveSpeed * Time.fixedDeltaTime);
    }



}
