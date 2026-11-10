using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

//This script just contains the UI information for the dialogue 

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

[Header ("Main Dialogue")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Transform choiceContainer;
    public GameObject choiceButtonPrefab;
    public Image npcImage;
    public GameObject itemHolder;
    public Image item;

[Header ("RestStop Dialogue")]
    private Reststop reststop;
    public TMP_Text restStopText;
    public GameObject restStopPanel;
    public Image iconImage;

    
    void Awake() //stops there from being multiple instances of this script
    {
        reststop = FindAnyObjectByType<Reststop>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        itemHolder.SetActive(false);
    }

    public void ShowDialogueUI(bool show)
    {
        if (!reststop.restStopActive)
        {
          dialoguePanel.SetActive(show);  
        }
        else
        {
         restStopPanel.SetActive(show); 
        }
        
    }

    public void SetNPCInfo(Sprite npcSprite)
    {
        if (!reststop.restStopActive)
        {
          npcImage.sprite = npcSprite;  
        }
        else
        {
           iconImage.sprite = npcSprite; 
        }
       
    }

    public void SetItemSprite(Sprite itemSprite)
    {
        itemHolder.SetActive(true);
        item.sprite = itemSprite;
    }

    public void SetDialogueText(string text) //gets the dialogue info 
    {
        if (!reststop.restStopActive)
        {
          dialogueText.text = text;  
        }
        else
        {
            restStopText.text = text;
        }
        
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

    //  public void CreateItemButton(UnityEngine.Events.UnityAction onClick)
    // {
    //     GameObject Button = Instantiate(itemButton);
    //     Button.GetComponent<Button>().onClick.AddListener(onClick);
    // }

}

