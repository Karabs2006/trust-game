using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 10f;

    public GameObject startInfo;
    public bool puzzleActive = true;
    private bool hasStarted;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        hasStarted = false;
    }

    
    void FixedUpdate() //Player moves to the right constantly
    {
        if (hasStarted)
        {
            if(!puzzleActive)
            {
                rb.linearVelocity = new Vector2(
                currentSpeed,
                rb.linearVelocity.y
            );
            } 
        }
    }

    public void OnPressStart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hasStarted = true;
            Destroy(startInfo);
        }
    }
}
