using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public PuzzlePosition puzzlePosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(FlashObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FlashObject(Color colorOne, Color colorTwo)
    {
        
        /*while(true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
        
            
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            

        }
        */

        puzzlePosition.timerText.color = colorOne;
        yield return new WaitForSeconds(0.5f);
        puzzlePosition.timerText.color = colorTwo;



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePlayer"))
        {
            
            //Transform transform = collision.GetComponent<Transform>();
            //EventInput eventInput = collision.gameObject.GetComponent<EventInput>();

            //eventInput.Respawn();
            StartCoroutine(FlashObject(Color.red, Color.white));
            puzzlePosition.timerInt -= 3;
            puzzlePosition.timerText.text = $"{puzzlePosition.timerInt}";
        
        }
    }

    

}
