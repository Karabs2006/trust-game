using UnityEngine;
using TMPro;

public class MiniInventory : MonoBehaviour
{
    public TMP_Text countText;
    
    public int amount;

    void Start()
    {
        countText.text = $"{amount}";
    }

    public void UseItem()
    {   
        if(amount != 0)
        {
            amount--;
            countText.text = $"{amount}";
        }
        
    }


}
