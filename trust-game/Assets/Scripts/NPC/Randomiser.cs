using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    public List<DialogueController> npcs = new List<DialogueController>();
    public Transform[] spawnPosition;
    private int spawnIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void RandomiseNPC()
    { 
        if (spawnIndex >= 6)
        {
            return;
        }
        int randomNum = Random.Range(0,3);
        List<DialogueController> spawnedNPC = new List<DialogueController>();
        foreach(DialogueController npc in npcs)
        {
            if(randomNum == npc.npcIndex)
            {
                if (npc == null)
                {
                    spawnedNPC.Add(npc);
                    Instantiate(npc,spawnPosition[spawnIndex]);
                    spawnIndex++; 
                }
                else
                {
                  Debug.Log("ahhh");  
                }
            }
        }
        //GameObject spawnNPC = npcs[Random.Range(0,3)]; //Randomises the npc spawned
        // Instantiate(spawnNPC,spawnPosition[spawnIndex]);
        // spawnIndex++; 
    }

}
