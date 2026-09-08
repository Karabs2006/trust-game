using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 10f;

    public bool puzzleActive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate() //Player moves to the right constantly
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
