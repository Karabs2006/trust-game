using UnityEngine;

public class RestStopDialogue : MonoBehaviour
{
    private Interactions player;
    public DialogueController npcDialogue;
    //public bool npcActive;
    private bool dialogueStarted;
    private bool wasPressed;
    private float delay = 1f;

    public void Awake()
    {
        player = FindAnyObjectByType<Interactions>();
    }
    
    public void Test()
    {
        if (!wasPressed)
        {
        if (!dialogueStarted)
        {
           npcDialogue.StartDialogue();
           
    
            wasPressed = true;
            Invoke(nameof(Reset), delay);
            dialogueStarted = true; 
            
        }
        else if (dialogueStarted)
        {
          npcDialogue.Interact(); 
            wasPressed = true;
            Invoke(nameof(Reset), delay);   
        }  
        }
       
        
        //Debug.Log("Thats something");
    }

    private void Reset()
    {
        wasPressed = false;
    }
    
}
