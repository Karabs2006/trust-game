using UnityEngine;

public class Destination : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject endScreen;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = FindAnyObjectByType<PlayerMovement>();
            player.currentSpeed = 0;
            endScreen.SetActive(true);
        }
    }
}
