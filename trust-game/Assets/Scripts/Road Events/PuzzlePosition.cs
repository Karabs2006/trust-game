using UnityEngine;
using System.Collections;
using TMPro;


public class PuzzlePosition : MonoBehaviour
{
    
    public TMP_Text timerText;
    int timerInt = 10;

    void Start()
    {
        timerText.text = $"{timerInt}";
        //StartCoroutine(Countdown());
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
        for(int i = 0; i<10; i++)
        {
            timerInt--;
            timerText.text = $"{timerInt}";
            yield return new WaitForSeconds(1f);
        }
       
    }
}
