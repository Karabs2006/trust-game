using UnityEngine;

public class CarHolder : MonoBehaviour
{
    //holds the information about the car, i,e who is in the car and how many slots there are, the atate the cae is in
    [Header ("General")]
    public Interactions interactions;
    
    [Header ("Pick Up")]
    public GameObject[] carSlots;
    private int slotIndex = 0;

    // [Header ("Leave")]
    // public GameObject[] openSlots;
    // private int openSlotIndex = 0;
    

    void Start()
    {
        interactions = FindAnyObjectByType<Interactions>();
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
            interactions.hit.collider.GetComponent<DialogueController>();
            if (interactions.hit)
            {
                DialogueController npc = GetComponent<DialogueController>();
                Debug.Log(npc.npcIndex);
                //Instantiate(thenpcObject, carSlots[slotIndex])
                slotIndex++;
                //move the npc to a slot
            }
            
        }
    }

    public void LeaveBehind()
    {
        
    }
}
