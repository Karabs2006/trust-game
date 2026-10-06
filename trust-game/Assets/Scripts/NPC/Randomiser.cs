using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    public GameObject standingNPC;
    public List<GameObject> npcs = new List<GameObject>();
    public Transform spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void randomiseNPC()
    {
        GameObject spawnNPC = npcs[Random.Range(0,6)]; //Randomises the npc spawned
        Instantiate(spawnNPC,spawnPosition);
        return;
    }

}
