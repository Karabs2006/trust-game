using UnityEngine;
using System.Collections;
using TMPro;


public class PuzzlePosition : MonoBehaviour
{
    
    public TMP_Text timerText;
    public TMP_Text loseText;
    public TMP_Text winText;
    public int timerInt = 30;
    public RoadEvent roadEvent;

    void Start()
    {
        timerText.text = $"{timerInt}";
        loseText.enabled = false;
        winText.enabled = false;
        //StartCoroutine(Countdown());
    }

    void Update()
    {
        if(timerInt <= 0)
            {
                loseText.enabled = true;
                roadEvent.puzzle.SetActive(false);
                roadEvent.trunkInventory.SetActive(false);

            }
    }


    //Spawn the puzzle on the far right side ofthe cameras position
    private void OnEnable()
    {
        Vector3 screenPosition = new Vector3(
            Screen.width * 0.75f,
            Screen.height * 0.7f,
            10f
        );

        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
    }



    public IEnumerator Countdown() //Timer for puzzle
    {   
        for(int i = 30; i >=0 ; i--)
        {
            timerInt--;
            timerText.text = $"{timerInt}";
            yield return new WaitForSeconds(1f);

            
        }
       
    }
}
