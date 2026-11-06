using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public Animator endingAnim;
    public GameObject infoHolder;
    
    public void Ending()
    {
     endingAnim.Play("EndingScreen");   
    }

    public void aniEvent()
    {
        infoHolder.SetActive(true);
    }
}
