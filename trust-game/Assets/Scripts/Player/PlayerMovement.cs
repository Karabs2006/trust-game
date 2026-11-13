//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 10f;

    public GameObject startInfo;
    public bool puzzleActive = true;
    private bool hasStarted;
    public bool isMoving;

    public Sprite skullImg;
    public Sprite carImg;
    public Image mainImg;
    public Animator animator;
    public Image speedometerImg;

    //public SpriteRenderer spriteRenderer;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        hasStarted = false;
        //spriteRenderer = mainImg.GetComponent<SpriteRenderer>();

        //spriteRenderer.sprite = carImg;

        mainImg.sprite = carImg;
        animator.speed = 1f;

    }

    
    void FixedUpdate() //Player moves to the right constantly
    {
        if (hasStarted)
        {
            if(!puzzleActive)
            {
                rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
                isMoving=true;
            }
            else
            {
                isMoving= false;
            }
        }
    }

    public void OnPressStart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hasStarted = true;
            Destroy(startInfo);
            isMoving = true; 
        }
    }
}
