using UnityEngine;

public class StartPuzzleThree : MonoBehaviour
{
    public ColourTrack colourTrack;
    public PuzzleThreeTimer puzzleThreeTimer;
    public GameObject button;

    /*
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && puzzleThreeTimer.start == true)
            {
                colourTrack.randomise();
            }
        }
    */

    public void StartPuzzle()
    {
        puzzleThreeTimer.start = true;
        colourTrack.randomise();
        button.SetActive(false);
    }
}
