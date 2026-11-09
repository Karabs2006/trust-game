using UnityEngine;
using System.Collections;

public class EndingManager : MonoBehaviour
{
    public Animator endingAnim;
    public GameObject endingScreen;
    public GameObject infoHolder;
    private PlayerMovement player;
    
    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    
    }
    public void Ending()
    {
    StartCoroutine("SlowDown");
    player.currentSpeed = 3;
    endingScreen.SetActive(true);
    endingAnim.Play("EndingScreen");   
    }

    public void aniEvent()
    {
        infoHolder.SetActive(true);
    }

     IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(1);
        player.currentSpeed = 0;
    }

}
