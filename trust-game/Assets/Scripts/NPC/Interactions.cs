using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private RaycastHit2D hit;
    private bool hasObject;
    private bool isInteracting;
    private bool wasPressed;
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.right * 3, Color.green);
        hit = Physics2D.Raycast(transform.position, Vector2.right, 3, LayerMask.GetMask("NPC"));
        if (hit)
        {
            hasObject = true;
        }
    }

    // public DialogueController controller;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            if (hasObject)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    Debug.Log("Hit");

                }
            }   
        }
        DialogueController controller = hit.collider.GetComponent<DialogueController>();
        if (!controller.isDialogueActive)
        {
            playerMovement.currentSpeed = 10f;
        }

    }
    


    // public void Test()
    // {
    //     controller.Interact(); 
    // }

}
