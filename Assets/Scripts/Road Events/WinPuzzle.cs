using UnityEngine;

public class WinPuzzle : MonoBehaviour
{
    public PuzzlePosition puzzlePosition;
    public RoadEvent roadEvent;
    private PlayerMovement player;
    public GameObject moodMeter;

    public GameObject puzzleTwo;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePlayer") || other.CompareTag("PuzzlePlayerTwo"))
        {
            moodMeter.SetActive(true);
            player.puzzleActive=false;
            player.currentSpeed = 10;
            //puzzlePosition.winText.enabled = true;
            roadEvent.puzzle.SetActive(false);
            roadEvent.trunkInventory.SetActive(false);
            
        }

        if (other.CompareTag("PuzzlePlayerTwo"))
        {
            moodMeter.SetActive(true);
            player.puzzleActive=false;
            player.currentSpeed = 10;
            puzzleTwo.SetActive(false);
            roadEvent.puzzle.SetActive(false);
            roadEvent.trunkInventory.SetActive(false);
            
            
            
        }
    }
}
