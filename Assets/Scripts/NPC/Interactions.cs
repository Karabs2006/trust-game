
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public RaycastHit2D hit;
    public GameObject text;
    private bool hasObject;
    private bool wasPressed;
    private float delay = 1f;
    [HideInInspector] public bool isDialogueActive;

    void FixedUpdate() 
    {
        Debug.DrawRay(transform.position, Vector2.right * 3, Color.green);
        hit = Physics2D.Raycast(transform.position, Vector2.right, 3, LayerMask.GetMask("NPC"));
        if (hit)
        {
            hasObject = true;
            isDialogueActive = true;
        }
        else
        {
           isDialogueActive = false; 
        }
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            if (!wasPressed)
            {
               if (hasObject)
                {
                text.SetActive(true);
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                    {
                    interactable.Interact();
                    wasPressed = true;
                    Invoke(nameof(Reset), delay);
                    }
                }   
            } 
        }
            
        DialogueController controller = hit.collider.GetComponent<DialogueController>();
        if (!controller.isDialogueActive)
        {
            isDialogueActive = false;
            playerMovement.currentSpeed = 10f;
            text.SetActive(false);
        }

    }

    private void Reset()
    {
        wasPressed = false;
    }

    

}
