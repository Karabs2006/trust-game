using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;


public class PuzzleThreeTimer : MonoBehaviour
{   
    public TMP_Text timerText;
    public TMP_Text solvedText;
    public TMP_Text lossText;
    public int timeInt = 60;
    public int solvedInt = 0;
    public GameObject puzzle;
    public PlayerMovement playerMovement;
    public ColourTrack colourTrack;

    public bool start = false;

    private Coroutine timerCoroutine;

    
    void Start()
    {
        timerText.text = $"{timeInt}";
        //StartCoroutine(Countdown());
        //start = true;
    }

    void FixedUpdate()
    {
        if (start)
        {
            start = false;

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine(Countdown());
        }

        if(solvedInt == 5)
        {
            puzzle.SetActive(false);
            playerMovement.currentSpeed = 10;
            playerMovement.rb.linearVelocity = new Vector2(playerMovement.currentSpeed, playerMovement.rb.linearVelocity.y);
            playerMovement.puzzleActive = false;
            playerMovement.mainImg.sprite = playerMovement.carImg;
            playerMovement.animator.speed = 1f;
        }

        if(timeInt == 0 && solvedInt < 5)
        {   
            lossText.enabled = true;
            puzzle.SetActive(false);

        }
    }

    IEnumerator Countdown()
    {
        while(timeInt > 0)
        {   
            //Debug.Log(timeInt);
            timeInt--;
            timerText.text = $"{timeInt}";
            yield return new WaitForSecondsRealtime(1f);
        }

        timerCoroutine = null;
    }

    public void Reset()
    {   
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        solvedInt = 0;
        timeInt = 60;
        start = true;
        solvedText.text =$"{solvedInt}";
        timerText.text = $"{timeInt}";
        colourTrack.coolDown = 1f;
        colourTrack.indicatorIndex = 0;
        colourTrack.inputColours.Clear();
        colourTrack.inputList = "";
    
        foreach(Image image in colourTrack.playerIndicators)
        {
            image.color = Color.white;
        }
        colourTrack.randomise();

    }
}
