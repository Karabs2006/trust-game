using System.Collections;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    [Header("NPC Data")]
    public NPCInfo dialogueData;
 
    [Header("Dialogue Data")]
    private DialogueUI dialogueUI;
    private int dialogueIndex;
    private bool isTyping;

    [HideInInspector] public bool isDialogueActive;

    void Start()
    {
        dialogueUI = DialogueUI.Instance;
    }

    public void Interact() //Call this when the player interacts with an NPC
    {
    
        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    public bool IsInteractable()
    {
        return !isDialogueActive;
    }

    void StartDialogue()
    {
       
        {
            isDialogueActive = true;
            dialogueIndex = 0;
       
        // {
        // //     dialogueIndex = dialogueData.inProgressIndex;
        // // // }
        // // else if (objectiveState == ObjectiveState.Incorrect)
        // // {
        // //     dialogueIndex = dialogueData.incorrectItemIndex;

        // //     flames.Play();
        // //     SoundManager.Play("Wrong");
        // // }
        // // else if (objectiveState == ObjectiveState.Correct)
        // // {
        // //     dialogueIndex = dialogueData.correctItemIndex;

        // }


        dialogueUI.ShowDialogueUI(true); //brings up the dialogue panel 

        DisplayCurrentLine();
    }
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

        if(dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        foreach(DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.ChoiceIndex == dialogueIndex)
            {
                return;
            }
        }


        if (dialogueData.givesItem.Length > dialogueIndex && dialogueData.givesItem[dialogueIndex])
        {
            EndDialogue();
            //GiveReward();

            return;
        }

        if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();

            return;
        }

        if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
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

    // void GiveReward()
    // {
    //     Item reward = Instantiate(dialogueData.objective.objectiveReward).GetComponent<Item>();
    //     reward.PickUp(holdPoint);

    //     Debug.Log("Reward granted");
    // }

    void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(Typewriter());
    }

    void DisplayChoices(DialogueChoice choice)
    {
        for(int i = 0; i < choice.choices.Length; i++)
        {
            int NextLine = choice.nextDialogueIndex[i];
            //dialogueUI.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
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

        isDialogueActive = false;
        dialogueUI.SetDialogueText("");
        dialogueUI.ShowDialogueUI(false);
    }

}
