using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 10f;


    public bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate() //Player moves to the right constantly
    {
        rb.linearVelocity = new Vector2(-currentSpeed, rb.linearVelocity.y);
          
    }
}
