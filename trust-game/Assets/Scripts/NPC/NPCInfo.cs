using UnityEngine;

//This script contains the information for the NPCS, its used to create the scriptable objects 

[CreateAssetMenu(fileName = "NPCInfo", menuName = "DialogueData")]
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

    [Header ("Choices")]
    public DialogueChoice[] choices;
    public bool[] givesItem; //whatever number is ticked an item will be given on that line
}

[System.Serializable]
public class DialogueChoice
{
    public int choiceIndex; //the lines where choices appear
    public string[] choices; //the players dialogue options
    public int[] nextDialogueIndex; // the response from the NPC
}
