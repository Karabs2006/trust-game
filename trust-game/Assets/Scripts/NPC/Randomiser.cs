using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    public List<DialogueController> npcs = new List<DialogueController>();
    List<DialogueController> spawnedNPC = new List<DialogueController>();
    public Transform[] spawnPosition;
    private int randomNum;
    private int spawnIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Onpress()
    {
        randomNum = Random.Range(1,7);
        Debug.Log(randomNum);
        RandomiseNPC();
    }

    public DialogueController RandomiseNPC()
    { 
        if (spawnIndex >= 5)
        {
            return null;
        }
        
        foreach(DialogueController npc in spawnedNPC)
        {
            if(randomNum == npc.npcIndex)
            {
                return null;  
            }
        }
        foreach(DialogueController npc in npcs)
        {
            if(randomNum == npc.npcIndex)
            {
                spawnedNPC.Add(npc);
                Debug.Log(spawnedNPC);
                Instantiate(npc,spawnPosition[spawnIndex]);
                spawnIndex++; 
            }
        }
        
        // return null;
        return null;
        //GameObject spawnNPC = npcs[Random.Range(0,3)]; //Randomises the npc spawned
        // Instantiate(spawnNPC,spawnPosition[spawnIndex]);
        // spawnIndex++; 
    }

}
