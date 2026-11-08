using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/VHS")]
public class VHS : Item
{
    public override void Use()
    {
      GameObject moodMeter = GameObject.Find("MoodMeter");
      Slider moodSlider = moodMeter.GetComponent<Slider>();

      moodSlider.value += 200;
      Debug.Log(moodSlider.value);
    
    }
}