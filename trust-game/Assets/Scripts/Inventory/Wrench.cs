using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Wrench")]
public class Wrench : Item
{
    public override void Use()
    {
        GameObject timer = GameObject.Find("Timer");
        TMP_Text tMP_Text = timer.GetComponent<TMP_Text>();

    //Test if button click works
        tMP_Text.text = "You used to call me on my cellphone";
        Debug.Log(tMP_Text.text);


    }
}