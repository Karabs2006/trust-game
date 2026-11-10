using UnityEngine;

public class Cutscene : MonoBehaviour
{
    private Animator tv;
    public GameObject panel;

    public void End()
    {
        panel.SetActive(false);
    }
}
