using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour, IInteractable
{
    [Header("NPC Data")]
    public NPCInfo dialogueData;
    public int npcIndex;
    public GameObject npcController;
    public bool isInfected;
    //public ParticleSystem spores;

     private CarHolder pickupActions;
     private Reststop reststop;

    [Header("Item Data")]
    public Item itemInfo;
 
    [Header("Dialogue Data")]
    private DialogueUI dialogueUI;
    private int dialogueIndex;
    private bool isTyping;
    private bool givenLift;

    [HideInInspector] public bool isDialogueActive;

    [Header("RoadEvents")]
    public GameObject puzzleHolder; // assign specific puzzle here

    public bool isCutscene;

    public string puzzleGameObjName;

    //public Transform passengerPanel;
  
    void Start()
    {
        dialogueUI = DialogueUI.Instance;
        dialogueUI.ShowDialogueUI(false); 
        pickupActions = FindAnyObjectByType<CarHolder>();
        reststop = FindAnyObjectByType<Reststop>();

        puzzleHolder = GameObject.Find(puzzleGameObjName);


        /*
        if(puzzleHolder !=null )
        {
            //Puzzle Trigger
            GameObject colliderObj = puzzleHolder.transform.Find("PuzzleTrigger").gameObject;
            //Collider2D collider = colliderObj.GetComponent<Collider2D>();
            //colliderObj.SetActive(true);
            colliderObj.transform.position = transform.position + Vector3.right * 10f;
        }
        */

    }

    public DialogueController(int npcIndex)
    {
       this.npcIndex = npcIndex; 
    }

    public void Interact() //Call this when the player interacts with an NPC
    {
        if (dialogueData == null)
        {
            return;
        }
    
        if (isDialogueActive)
        {
            NextLine();
        }
        // else
        // {
        //     StartDialogue();
        // }
    }

    public bool IsInteractable()
    {
        return !isDialogueActive;
    }

    public void StartDialogue()
    {
        isDialogueActive = true;
        givenLift = false;
        dialogueIndex = 0;

        dialogueUI.SetNPCInfo(dialogueData.npcSprite); 
        dialogueUI.ShowDialogueUI(true); //brings up the dialogue panel 

        DisplayCurrentLine();

        if(isInfected)
        {
           //spores.Play(); 
           Debug.Log("spores");
        }

        // GameObject passenger = new GameObject(dialogueData.name);
        // passenger.transform.SetParent(passengerPanel, false);

        // Image passengerSprite = passenger.AddComponent<Image>();
        // passengerSprite.sprite = dialogueData.npcSprite;
    
    }


    void NextLine()
    {
        if (isTyping)
        {
            //skips the typing "animation"
            StopAllCoroutines();

            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        dialogueUI.ClearChoices();

        //Reward
        if (dialogueData.givesItem.Length > dialogueIndex && dialogueData.givesItem[dialogueIndex])
        {
            Debug.Log("GiveReward");
            GiveReward();
            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueData.nextDialogueIndexI]); 
            //Sprite passengerSprite = Instantiate(dialogueData.npcSprite, passengerPanel);
        }


        //Ends Dialogue
        if(dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            
            //Debug.Log("Ended");
            StartCoroutine("Wait");
            return;  

        }


        //Choices
        foreach(DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.choiceIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }

        //Options
        if (dialogueData.giveLiftIndex.Length > dialogueIndex && dialogueData.giveLiftIndex[dialogueIndex])
        {
            //Give a lift option
            if (!pickupActions.carFull)
            {
            givenLift = true;
            StartCoroutine("Wait");
            return;  
            }
            else
            {
                //Full Line
            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueData.carFullIndex]); 
            givenLift = false;
            StartCoroutine("Wait");
            return;  
            }
           
           
        }
        if (dialogueData.leaveBehindIndex.Length > dialogueIndex && dialogueData.leaveBehindIndex[dialogueIndex])
        {
            //Leave Behind option
            givenLift = false;
            StartCoroutine("Wait");
            return;    
    
        }
        
        //NextLine
        if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Typewriter() 
    {
        isTyping = true;

        dialogueUI.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueUI.SetDialogueText(dialogueUI.dialogueText.text += letter);

            yield return new WaitForSeconds(dialogueData.dialogueSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);

            NextLine();
        }
    }

    void GiveReward()
    {
        dialogueUI.SetItemSprite(itemInfo.icon); 
        Item reward = Instantiate(dialogueData.item); //gets the information of the item
        Debug.Log(reward);

        GameObject inventoryObject = GameObject.Find("ScriptHolderInv");
        Inventory inventoryScript = inventoryObject.GetComponent<Inventory>();
        

        if(itemInfo.inventoryGroup == "Trunk")
        {
            inventoryScript.AddItem("trunk", itemInfo,inventoryScript.buttonPrefab, inventoryScript.inventoryPanel);
            Debug.Log("ITEM IN TRUNK");
        }

        if(itemInfo.inventoryGroup == "Mini")
        {
            //GameObject subGroupObj = GameObject.Find($"{itemInfo.miniInvSubGroup}");
            //GameObject scriptHolder = subGroupObj.transform.Find("Script").gameObject;
            //MiniInventory miniInventory = scriptHolder.GetComponent<MiniInventory>();

            //miniInventory.amount++;
            //miniInventory.countText.text = $"{miniInventory.amount}";

            inventoryScript.AddItem("mini", itemInfo,inventoryScript.buttonPrefabMini, inventoryScript.inventoryPanelMini);
            Debug.Log("ITEM IN MINI");

        }
    }


    void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(Typewriter());
    }

    void DisplayChoices(DialogueChoice choice)
    {
        for(int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialogueIndex[i];
            dialogueUI.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
        }
    }

    void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        dialogueUI.ClearChoices();
        DisplayCurrentLine();
    }

    public void EndDialogue()
    {
        StopAllCoroutines();

        dialogueUI.itemHolder.SetActive(false);
        isDialogueActive = false;
        dialogueUI.SetDialogueText("");
        dialogueUI.ShowDialogueUI(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        if (givenLift)
        {
            if (!reststop.restStopActive)
            {
               pickupActions.PickUp();
            if(npcIndex == 5)
            {
                if(puzzleHolder !=null )
                {
                    //Puzzle Trigger
                    GameObject colliderObj = puzzleHolder.transform.Find("PuzzleTrigger").gameObject;
                    colliderObj.transform.position = transform.position + Vector3.right * 10f;
                }
            }    
            }
            else
            {
                EndDialogue();  
            }
           
            //Debug.Log("PickedUp");
        }
        else if (!givenLift)
        {
            if (!isCutscene)
            {
                if (!reststop.restStopActive)
                {
                    pickupActions.LeaveBehind();
                    
                    if(npcIndex != 5)
                    {
                        if(puzzleHolder !=null )
                        {
                            //Puzzle Trigger
                            GameObject colliderObj = puzzleHolder.transform.Find("PuzzleTrigger").gameObject;
                            colliderObj.transform.position = transform.position + Vector3.right * 10f;
                        }
                    }  
                }
                else
                {
                  EndDialogue();
                   npcController.SetActive(false); 
                }
            
            //Debug.Log("LeftBehind");  
            }
            else
            {
              EndDialogue();    
            }  
        }

        yield return new WaitForSeconds(0.5f);
        //Debug.Log("Wait");
        EndDialogue();  
    }


}
