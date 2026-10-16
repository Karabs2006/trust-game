using UnityEngine;
using TMPro;

public class MiniInventory : MonoBehaviour
{
    public TMP_Text countText;
    public MoodMeter moodMeterScript;
    
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
            moodMeterScript.moodMeter.value += 100; 
        }
        
    }


}
