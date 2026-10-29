
using System.Collections.Generic;
using UnityEngine;

public class CarHolder : MonoBehaviour
{
    //holds the information about the car, i,e who is in the car and how many slots there are, the state the cae is in
    [Header ("General")]
    public Interactions interactions;
    private DialogueController npc;
    
    [Header ("Pick Up")]
    public Transform[] carSlots;
    private int slotIndex = 0;
    public MoodMeter moodBar;
    private InfectionBar infectionBar;
    public List<DialogueController> npcIcons = new List<DialogueController>();

    [Header ("Leave Behind")]
    public Transform[] openSlots;
    private int openSlotIndex = 0;
    private int ranNum;
    public Transform[] puzzleSpawnPoint;
    private int puzzleNum = 0;
    private RoadEvent REcollider;

    public void FixedUpdate()
    {
        //CarState();
    }

    public void PickUp()
    {
        if(slotIndex >= 4)
        {
           Debug.Log("CarFull"); 
            return;
        }
        else
        {
            npc = interactions.hit.collider.GetComponent<DialogueController>();
            if (npc != null)
            {   
                foreach (DialogueController icon in npcIcons)
                {
                    if (npc.npcIndex == icon.npcIndex)
                    {
                        Instantiate(icon.npcController, carSlots[slotIndex]); 
                        slotIndex++;
                        Debug.Log("Picked up");

                        if(npc.npcIndex == 5) //Fiona 
                        {
                        Instantiate(icon.npcController, openSlots[openSlotIndex]);
                        openSlotIndex++;
                        }
                    }
                }
                
            
            }
            if (npc.isInfected)
            {
                infectionBar = FindAnyObjectByType<InfectionBar>();
                infectionBar.StartCoroutine("SetVisible"); //infection bar goes up
                Debug.Log("Infected");
                //visual effect
                
            }
            
        }
    }

    public void LeaveBehind()
    {
        if(openSlotIndex >= 7)
        {
           Debug.Log("Break"); 
            return;
        }
        else
        {
            npc = interactions.hit.collider.GetComponent<DialogueController>();
            if (npc != null)
            {
                if(npc.npcIndex == 5) //Fiona
                {
                    return;
                }
                else
                {
                Instantiate(npc.npcController, openSlots[openSlotIndex]);
                openSlotIndex++; 
                }
                
            } 
        }
         
    }

    public void Randomise()
    {
        ranNum = Random.Range(0,8);
        Debug.Log(ranNum);
    }
    public void RoadEventRandomiser()
    {
        foreach (Transform npcTransform in openSlots)
        {
            npc = npcTransform.GetComponent<DialogueController>();
            if (ranNum == npc.npcIndex)
            {
                Instantiate(npc.puzzleHolder,puzzleSpawnPoint[puzzleNum]);
                puzzleNum++;
            }
            else
            {
                REcollider = FindFirstObjectByType<RoadEvent>();
                REcollider.Randomise();
            }
        }
    }

    public void CarState()
    {
        foreach (Transform npcTransform in carSlots)
        npc = npcTransform.GetComponent<DialogueController>();
        {
            if (npc.npcIndex == 3) //Acelot Tags
            {
            moodBar.moodValueD = 0.5f;
            }
            else
            {
            moodBar.moodValueD = 0.01f; 
            }  
        }
        
    }
}
