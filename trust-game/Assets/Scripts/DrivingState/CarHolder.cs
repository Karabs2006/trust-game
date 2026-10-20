using UnityEngine;

public class CarHolder : MonoBehaviour
{
    //holds the information about the car, i,e who is in the car and how many slots there are, the atate the cae is in
    [Header ("General")]
    public Interactions interactions;
    
    [Header ("Pick Up")]
    public Transform[] carSlots;
    private int slotIndex = 0;

    [Header ("Leave Behind")]
    public Transform[] openSlots;
    private int openSlotIndex = 0;
    
    public void PickUp()
    {
        if(slotIndex >= 4)
        {
           Debug.Log("CarFull"); 
            return;
        }
        else
        {
            DialogueController npc = interactions.hit.collider.GetComponent<DialogueController>();
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
           DialogueController npc = interactions.hit.collider.GetComponent<DialogueController>();
            if (npc != null)
            {
                //Debug.Log(npc.npcIndex);
                Instantiate(npc.npcController, openSlots[openSlotIndex]);
                //Debug.Log("Picked up");
                openSlotIndex++;
            } 
        }
         
    }
}
