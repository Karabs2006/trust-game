using UnityEngine;

public class NPCEvent : MonoBehaviour
{
    public DialogueController dialogueController;

    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop Player Movement when puzzle is active
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            playerMovement.currentSpeed = 0;

            //calls dialogue
            dialogueController.StartDialogue();
        }
    }

  
}
