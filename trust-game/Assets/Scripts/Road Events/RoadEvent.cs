using UnityEngine;
using System.Collections;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class RoadEvent : MonoBehaviour
{

    public GameObject puzzle;
    public PuzzlePosition puzzlePosition;
    public GameObject trunkInventory;
    public PlayerMovement playerMovement;
    public GameObject moodMeter;
    public CarHolder puzzleRandomiser;
    public Image kilometerImg;

    public Image skullImg;

    void Start()
    {
        puzzle.SetActive(false);
        trunkInventory.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop Player Movement when puzzle is active
            
            SoundEffectManager.Play("CarBreakdown");
            SoundEffectManager.SetVolume(1f);
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.currentSpeed = 0;
            playerMovement.rb.linearVelocity = Vector2.zero;
            playerMovement.puzzleActive = true;
            playerMovement.mainImg.sprite = playerMovement.skullImg;
            //Randomise();
           

            moodMeter.SetActive(false);
    

            puzzle.SetActive(true);
            trunkInventory.SetActive(true);
            PuzzleCheck.currentPuzzle = puzzle;
            PuzzleCheck.trunkInv = trunkInventory;
            //puzzlePosition.StartCoroutine(puzzlePosition.Countdown());
        }
    }

    public void Randomise()
    {
        puzzleRandomiser.Randomise();
        puzzleRandomiser.RoadEventRandomiser(); //This sets the puzzle to the position
    }
}

