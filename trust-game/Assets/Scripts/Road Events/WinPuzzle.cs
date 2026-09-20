using UnityEngine;

public class WinPuzzle : MonoBehaviour
{
    public PuzzlePosition puzzlePosition;
    public RoadEvent roadEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuzzlePlayer"))
        {
            puzzlePosition.winText.enabled = true;
            roadEvent.puzzle.SetActive(false);
            roadEvent.trunkInventory.SetActive(false);
            
        }
    }
}
