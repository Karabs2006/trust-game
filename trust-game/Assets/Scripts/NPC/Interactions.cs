using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    public DialogueController controller;

    public void OnInteract(InputAction.CallbackContext context)
    {   if (context.performed)
        {
            Debug.Log("button pressed");
          controller.Interact();  
        }
        else
        {
            return;
        }
    }
}
