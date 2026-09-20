using UnityEngine;

public class NPCEvent : MonoBehaviour
{
    public DialogueController dialogueController;
    public PlayerMovement playerMovement;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop Player Movement when dialogue is active
            playerMovement.currentSpeed = 0;

            //calls dialogue
            dialogueController.StartDialogue();
        }
    }


  
}
