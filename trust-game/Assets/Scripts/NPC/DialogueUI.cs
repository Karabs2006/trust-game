using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

//This script just contains the UI information for the dialogue 

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Transform choiceContainer;
    public GameObject choiceButtonPrefab;
    public Image npcImage;
    public Image itemHolder;
    
    
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

    public void ShowDialogueUI(bool show)
    {
        dialoguePanel.SetActive(show);
    }

    public void SetNPCInfo(Sprite npcSprite)
    {
       npcImage.sprite = npcSprite;
    }

    public void SetItemInfo(Sprite item, String itemname)
    {
        itemHolder.sprite = item; 
    }

    public void SetDialogueText(string text) //gets the dialogue info 
    {
        dialogueText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in choiceContainer) Destroy(child.gameObject);
    }

    public void CreateChoiceButton(string choiceText, UnityEngine.Events.UnityAction onClick)
    {
        GameObject choiceButton = Instantiate(choiceButtonPrefab, choiceContainer);
        choiceButton.GetComponentInChildren<TMP_Text>().text = choiceText;
        choiceButton.GetComponent<Button>().onClick.AddListener(onClick);

    }
}

