using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(FlashObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlashObject()
    {
        while(true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
        
            
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePlayer"))
        {
            
            //Transform transform = collision.GetComponent<Transform>();
            EventInput eventInput = collision.GetComponent<EventInput>();

            eventInput.Respawn();



        }
    }

}
