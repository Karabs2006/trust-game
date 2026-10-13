using UnityEngine;
using TMPro;

public class ObstacleCollide : MonoBehaviour
{
    public TMP_Text timerText;
    public int tryCount = 4;
    public GameObject puzzleTwo;
    public IntCounter intCounter;
    public TMP_Text lossText;


    void Start()
    {
        puzzleTwo = GameObject.Find("PuzzleTwo");
        intCounter = puzzleTwo.GetComponent<IntCounter>();
        
        timerText.text = $"{intCounter.tryCount}";

    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
    
        if (collision.gameObject.CompareTag("PuzzlePlayerTwo"))
        {
           Debug.Log("Trash boat");

            intCounter.tryCount--;
            timerText.text = $"{ intCounter.tryCount}";

            if(intCounter.tryCount == 0)
            {
                Debug.Log("You lost twin");
                puzzleTwo.SetActive(false);
                intCounter.ShowLoss();

            }
           
        
        }
    }
}
