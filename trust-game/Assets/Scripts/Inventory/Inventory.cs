using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject buttonPrefab;
    public Transform inventoryPanel;
    
    void Start()
    {
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
            buttonArea.onClick.AddListener(() => item.Use());
        }
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
