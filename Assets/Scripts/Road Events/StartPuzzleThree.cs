using UnityEngine;

public class StartPuzzleThree : MonoBehaviour
{
    public ColourTrack colourTrack;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colourTrack.randomise();
        }
    }
}
