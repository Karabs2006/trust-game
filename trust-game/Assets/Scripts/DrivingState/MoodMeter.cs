using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoodMeter : MonoBehaviour
{
    [Header("MoodMeter")]
    public Slider moodMeter;
    public int fullMood;
    public float moodValueD = 2f; //the value to decrease by
    private bool decreasing;

    [Header("Influences")]
    private int moodIncrease = 100; //the amount the mood will increase by
    public PlayerMovement player;
    public Interactions dialogue;
    public Reststop restStop;
    private EndingManager ending;
    public GameObject text;

    void Start()
    {
        moodMeter = GetComponent<Slider>();
        moodMeter.maxValue = fullMood;
        moodMeter.value = fullMood;
        ending = FindAnyObjectByType<EndingManager>();
    }

    void FixedUpdate()
    {
        if (!decreasing)
        {
            MoodManager(); 
        }
        if (dialogue.isDialogueActive || restStop.restStopActive)
        {
            decreasing = false;
        }
        //Debug.Log(moodMeter.value);
        
    }

    IEnumerator DecreaseMood()
    {
        if (decreasing)
        {
          while(moodMeter.value > 0)
        {
            moodMeter.value -= moodValueD * 0.01f;//ime.deltaTime;
            yield return null;
        }
        ending.Ending();
        text.SetActive(true);  
        }
         
        //value decreases entirely (effect)
        //crash, game over
       
    }
    IEnumerator IncreaseMood()
    {
         while(moodMeter.value < 5000)
        {
            moodMeter.value += 10f /200f;
            if (moodMeter.value > moodMeter.maxValue) moodMeter.value = moodMeter.maxValue;
            yield return null;
        } 
    }

    public void ItemUsed() //when an item is used to increase mood
    {
      StartCoroutine("Reset");
      StopCoroutine("DecreaseMood");
      moodMeter.value += moodIncrease; 
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("DecreaseMood");
        StopCoroutine("Reset");
    }

    public void MoodManager()
    {
       
        if (restStop.restStopActive)
        {
          StopCoroutine("DecreaseMood");  
          StartCoroutine("IncreaseMood");
        }
        else
        { 
          StopCoroutine("IncreaseMood"); 
          if (player.isMoving && !dialogue.isDialogueActive)
            {
                decreasing = true;
                StartCoroutine("DecreaseMood"); 
            }
            else if (!player.isMoving || dialogue.isDialogueActive)
            {
                StopCoroutine("DecreaseMood"); 
                decreasing = false;
            }
        }
       
    }
    
}
