using UnityEngine;

public class NPCInfo : ScriptableObject
{
    [Header("NPC Details")]
    public Sprite npcSprite;

    [Header("Dialogue")]
    public string[] dialogueLines;
    public bool[] autoProgressLines; //if true will autoprogress instead of a button press
    public bool[] endDialogueLines; //if True = the dialogue doesnt continue 
    public float autoProgressDelay = 1.5f;
    public float dialogueSpeed = 0.05f;

    [Header ("Responses")]
    //Assign in the inspector, jumps to the line of dialogue that is the response
    public int response1; 

  
    public bool[] givesItem;
}
