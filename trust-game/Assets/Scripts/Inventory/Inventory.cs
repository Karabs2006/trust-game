using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEditor;

public class Inventory : MonoBehaviour
{
    public List<Item> trunkItems = new List<Item>();

    public List<Item> miniItems = new List<Item>();

    //Trunk inventory
    public GameObject buttonPrefab;
    public Transform inventoryPanel;

    //Mini Inventory
    public GameObject buttonPrefabMini;
    public Transform inventoryPanelMini;

    void Start()
    {   
        /*
        foreach(Item item in items)
        {
            //Reuse this to put item in the inventory
            //We will swap name logic to actual images/icons

            GameObject button = Instantiate(buttonPrefab, inventoryPanel);
            TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
            tMP_Text.text = $"{item.itemName}";
            Debug.Log(item.itemName);

            //Run the use function for each respective item
            Button buttonArea = button.GetComponent<Button>();
            buttonArea.onClick.AddListener(() =>{ 
            item.Use();
            button.SetActive(false);
            });
        }

        */

    }

    public void AddItem(List<Item> itemList, Item newItem, GameObject prefab, Transform itemArea)
    {
        itemList.Add(newItem);

        GameObject button = Instantiate(prefab, itemArea);
        TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
        tMP_Text.text = $"{newItem.itemName}";
        Debug.Log(newItem.itemName);

        Button buttonArea = button.GetComponent<Button>();
        buttonArea.onClick.AddListener(() =>
        {
            newItem.Use();
            button.SetActive(false);
        });
    }

}
