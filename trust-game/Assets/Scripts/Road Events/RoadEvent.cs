using UnityEngine;
using System.Collections;

public class RoadEvent : MonoBehaviour
{

    public GameObject puzzle;
    public PuzzlePosition puzzlePosition;
    public GameObject trunkInventory;
    public PlayerMovement playerMovement;
    public GameObject moodMeter;
    public CarHolder puzzleRandomiser;


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
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.currentSpeed = 0;
            playerMovement.rb.linearVelocity = Vector2.zero;
            playerMovement.puzzleActive = true;
            Randomise();
           

            moodMeter.SetActive(false);
    

            puzzle.SetActive(true);
            trunkInventory.SetActive(true);
            //puzzlePosition.StartCoroutine(puzzlePosition.Countdown());
        }
    }

    public void Randomise()
    {
        puzzleRandomiser.Randomise();
        puzzleRandomiser.RoadEventRandomiser(); //This sets the puzzle to the position
    }
}

