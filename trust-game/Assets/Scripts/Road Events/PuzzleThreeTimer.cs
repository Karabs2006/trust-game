using UnityEngine;
using TMPro;
using System.Collections;


public class PuzzleThreeTimer : MonoBehaviour
{   
    public TMP_Text timerText;
    public TMP_Text solvedText;
    public int timeInt = 30;
    public int solvedInt = 0;
    public GameObject puzzle;
    public PlayerMovement playerMovement;

    void Start()
    {
        timerText.text = $"{timeInt}";
        StartCoroutine(Countdown());
    }

    void FixedUpdate()
    {
        if(solvedInt == 5)
        {
            puzzle.SetActive(false);
            playerMovement.currentSpeed = 10;
            playerMovement.rb.linearVelocity = new Vector2(playerMovement.currentSpeed, playerMovement.rb.linearVelocity.y);
        }
    }

    IEnumerator Countdown()
    {
        while(timeInt > 0)
        {   
            Debug.Log(timeInt);
            timeInt--;
            timerText.text = $"{timeInt}";
            yield return new WaitForSecondsRealtime(1f);

        }
    }
}
