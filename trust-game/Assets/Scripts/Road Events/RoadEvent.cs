using UnityEngine;
using System.Collections;

public class RoadEvent : MonoBehaviour
{

    public GameObject puzzle;
    public PuzzlePosition puzzlePosition;


    void Start()
    {
        puzzle.SetActive(false);
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

            playerMovement.currentSpeed = 0;

            puzzle.SetActive(true);
            puzzlePosition.StartCoroutine(puzzlePosition.Countdown());
        }
    }
}

