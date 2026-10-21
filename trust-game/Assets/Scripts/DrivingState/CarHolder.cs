using UnityEngine;

public class CarHolder : MonoBehaviour
{
    //holds the information about the car, i,e who is in the car and how many slots there are, the atate the cae is in
    [Header ("General")]
    public Interactions interactions;
    private DialogueController npc;
    
    [Header ("Pick Up")]
    public Transform[] carSlots;
    private int slotIndex = 0;

    [Header ("Leave Behind")]
    public Transform[] openSlots;
    private int openSlotIndex = 0;
    private int ranNum;
    

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
                //Debug.Log(npc.npcIndex);
                Instantiate(npc.npcController, carSlots[slotIndex]);
                //Debug.Log("Picked up");
                slotIndex++;
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
                //Debug.Log(npc.npcIndex);
                Instantiate(npc.npcController, openSlots[openSlotIndex]);
                //Debug.Log("Picked up");
                openSlotIndex++;
            } 
        }
         
    }

    public void RoadEventRandomiser()
    {
        ranNum = Random.Range(0,8);
        Debug.Log(ranNum);
        foreach (Transform npcTransform in openSlots)
        {
            npc = npcTransform.GetComponent<DialogueController>();
            if (ranNum == npc.npcIndex)
            {
                //set specific road event active
                //npc.RoadEvent.SetActive(True)
            }
        }
    }

    public void CarState()
    {
        
    }
}
