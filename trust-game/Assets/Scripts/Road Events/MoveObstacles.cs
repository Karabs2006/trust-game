using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public Rigidbody2D rb;
    public float currentSpeed = 10f;
    private Vector3 originalPosition;

    public bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.localPosition;
    }

    
    void FixedUpdate() //Obstacles moves to the right constantly
    {
        rb.linearVelocity = new Vector2(-currentSpeed, rb.linearVelocity.y);
          
    }

    public void Respawn()
    {
        
        /*Vector3 screenPosition = new Vector3(
            Screen.width * 0.1f,
            Screen.height * 0.5f,
            10f
        );

        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);*/

        transform.localPosition = originalPosition;
    }
}
