using TMPro;
using UnityEngine;

public class IntCounter : MonoBehaviour
{
    public int tryCount = 4;
    public TMP_Text lossText;
    public TMP_Text timerText;

    public void ShowLoss()
    {
        lossText.enabled = true;
    }
}
