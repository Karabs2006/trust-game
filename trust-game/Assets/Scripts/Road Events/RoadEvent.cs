using UnityEngine;
using System.Collections;

public class RoadEvent : MonoBehaviour
{

    public GameObject puzzle;
    public PuzzlePosition puzzlePosition;
    public GameObject trunkInventory;
    public PlayerMovement playerMovement;


    void Start()
    {
        puzzle.SetActive(false);
        trunkInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartEvent()
    {
        //Time.timeScale = 0f;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop Player Movement when puzzle is active
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            //playerMovement.currentSpeed = 0;
            playerMovement.puzzleActive = true;
            playerMovement.rb.linearVelocity = Vector2.zero;
    

            puzzle.SetActive(true);
            trunkInventory.SetActive(true);
            puzzlePosition.StartCoroutine(puzzlePosition.Countdown());
        }
    }
}

