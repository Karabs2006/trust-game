using UnityEngine;

public class RestStopDialogue : MonoBehaviour
{
    private Interactions player;
    public DialogueController npcDialogue;
    public void Awake()
    {
        player = FindAnyObjectByType<Interactions>();
    }
    public void Test()
    {
        npcDialogue.StartDialogue();
        player.hasObject = true;
        //Debug.Log("Thats something");
    }
}
