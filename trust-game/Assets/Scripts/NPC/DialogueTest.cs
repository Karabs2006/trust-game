using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public DialogueController controller;

    void Start()
    {
        controller = GetComponent<DialogueController>();
    }

    public void Test()
    {
        controller = GetComponent<DialogueController>();
        controller.Interact();
    }

  
}
