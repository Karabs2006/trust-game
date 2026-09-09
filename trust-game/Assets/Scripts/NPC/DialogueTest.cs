using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public DialogueController controller;

    void Start()
    {
        DialogueController controller = GetComponent<DialogueController>();
    }

    public void Test()
    {
        controller.Interact();
    }

  
}
