using UnityEngine;

public class Reststop : MonoBehaviour 
{
    private PlayerMovement playerMovement;
    public GameObject restStopView;
    public bool restStopActive;
    public GameObject inventory;
    public GameObject dialogue;
    //private CarHolder carHolder;
    // public RectTransform inventoryTransform;
    // public Vector2 rightSidePosition;
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
            SoundEffectManager.Play("GasStation");
            playerMovement.currentSpeed = 0;
            restStopView.SetActive(true);
            restStopActive = true;
            // inventory.SetActive(true);
            // inventoryTransform.anchoredPosition = rightSidePosition;
           
        }
    }

    // public void Interact()
    // {
    //     foreach (Transform transform in carHolder.carSlots)
    //     {
    //         RestStopDialogue npc = transform.GetComponentInChildren<RestStopDialogue>();
    //         if (npc.npcActive)
    //         {
    //             npc.NextLine();
    //         }
    //     }
    // }

    public void EndRestStop()
    {
        dialogue.SetActive(false);
        restStopView.SetActive(false);
        playerMovement.currentSpeed = 10;
        restStopActive = false;
        inventory.SetActive(false);
    }
}
