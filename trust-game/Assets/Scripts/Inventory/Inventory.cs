using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEditor;
using System;

public class Inventory : MonoBehaviour
{
    //public List<Item> trunkItems = new List<Item>();
    //public List<Item> miniItems = new List<Item>();

    //Trunk inventory
    public GameObject buttonPrefab;
    public Transform inventoryPanel;

    //Mini Inventory
    public GameObject buttonPrefabMini;
    public Transform inventoryPanelMini;

    public Wrench wrench;

    void Start()
    {   
        AddItem("trunk", wrench, buttonPrefab,inventoryPanel, wrench.icon);
    }

    public void AddItem(String group, Item newItem,GameObject prefab, Transform itemArea, Sprite itemImg)
    {
        if(group == "trunk")
        {
            ItemLists.AddTrunk(newItem);
        }

        if(group == "mini")
        {
            ItemLists.AddMini(newItem);
        }

        GameObject button = Instantiate(prefab, itemArea);
        //TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
        
        //tMP_Text.text = $"{newItem.itemName}";
        Debug.Log(newItem.itemName);

        Button buttonArea = button.GetComponent<Button>();
        buttonArea.image.sprite = itemImg;
        buttonArea.AddComponent<Tooltip>();
        Tooltip tooltip = buttonArea.GetComponent<Tooltip>();
        tooltip.toolDescription= newItem.description;

        buttonArea.onClick.AddListener(() =>
        {
            newItem.Use();
            tooltip.background.enabled = false;  
            tooltip.toolText.text = ""; 
            button.SetActive(false);
        });
    }

}
