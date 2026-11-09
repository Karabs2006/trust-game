using UnityEngine;

[CreateAssetMenu(menuName = "Items/Mixtape")]
public class Mixtape : Item
{
    public override void Use()
    {
        GameObject moodMeterObj = GameObject.Find("MoodMeter");
        MoodMeter moodMeter = moodMeterObj.GetComponent<MoodMeter>();

        moodMeter.moodValueD = 0.008f;
    }
}
