using UnityEngine;
using TMPro;

public class SuddenDeath : MonoBehaviour
{
   public GameObject puzzleTwo;
   public TMP_Text loseText;

    void Start()
    {
        loseText.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePlayerTwo"))
        {
            puzzleTwo.SetActive(false);
            loseText.enabled = true;
               
        }
    }
}
