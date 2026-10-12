using UnityEngine;

public class WinPuzzle : MonoBehaviour
{
    public PuzzlePosition puzzlePosition;
    public RoadEvent roadEvent;
    private PlayerMovement player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePlayer"))
        {
            player.puzzleActive=false;
            player.currentSpeed = 10;
            //puzzlePosition.winText.enabled = true;
            roadEvent.puzzle.SetActive(false);
            roadEvent.trunkInventory.SetActive(false);
            
            
        }
    }
}
