using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class MoodMeter : MonoBehaviour
{
    [Header("MoodMeter")]
    Slider moodMeter;
    public int fullMood;
    private float moodValueD = 0.005f; //the value to decrease by

    [Header("Influences")]
    private int moodIncrease = 100; //the amount the mood will increase by
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moodMeter = GetComponent<Slider>();
        moodMeter.maxValue = fullMood;
        moodMeter.value = fullMood;
    }

    void Update()
    {
        StartCoroutine("DecreaseMood");
        //MoodManager();
    }

    IEnumerator DecreaseMood()
    {
         while(moodMeter.value > 0)
        {
            moodMeter.value -= moodValueD * Time.deltaTime;
            yield return null;
        }
        //value decreases entirely (effect)
       
    }
    IEnumerator IncreaseMood()
    {
         while(moodMeter.value < 5000)
        {
            moodMeter.value += 0.2f /200f;
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
        //Anything that increases mood (As an if statement)
        // StartCoroutine("IncreaseMood");
        // StopCoroutine("DecreaseMood");
        // Anything that decreases mood 
        // StartCoroutine("DecreaseMood");
        //  StopCoroutine("IncreaseMood");

    }
    
}
