using UnityEngine;

public class Reststop : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject restStopView;
    public bool restStopActive;
    
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        restStopView.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop Player Movement when dialogue is active
            playerMovement.currentSpeed = 0;
            restStopView.SetActive(true);
            restStopActive = true;
           
        }
    }

    public void EndRestStop()
    {
        restStopView.SetActive(false);
        playerMovement.currentSpeed = 10;
        restStopActive = false;
    }
}
