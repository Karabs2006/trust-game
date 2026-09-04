using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    
    
    void Awake() //stops there from being multiple instances of this script
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDialogueUI()
    {
        dialoguePanel.SetActive(true);
    }

    public void SetDialogueText(string text) //gets the dialogue info 
    {
        dialogueText.text = text;
    }
}

