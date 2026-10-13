using UnityEngine;
using TMPro;

public class ObstacleCollide : MonoBehaviour
{
    public TMP_Text timerText;
    public int tryCount = 4;
    
    void Start()
    {
        timerText.text = $"{tryCount}";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePlayerTwo"))
        {
           Debug.Log("Trash boat");


           if(tryCount > 0)
            {
                tryCount--;
                timerText.text = $"{tryCount}";

            }

            if(tryCount == 0)
            {
                Debug.Log("You lost twin");
            }
           
        
        }
    }
}
