using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/MoviePlayer")]
public class MoviePlayer : Item
{
    public override void Use()
    {
      GameObject moodMeter = GameObject.Find("MoodMeter");
      Slider moodSlider = moodMeter.GetComponent<Slider>();
    
      moodSlider.value += 25;
      Debug.Log(moodSlider.value);

    }
}
