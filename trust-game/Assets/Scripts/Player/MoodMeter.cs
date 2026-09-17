using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class MoodMeter : MonoBehaviour
{
    Slider moodMeter;
    public int fullMood;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moodMeter = GetComponent<Slider>();
        moodMeter.maxValue = fullMood;
        moodMeter.value = fullMood;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("DecreaseMood");
        //MoodManager();
    }

    IEnumerator DecreaseMood()
    {
         while(moodMeter.value > 0)
        {
            moodMeter.value -= 0.01f * Time.deltaTime;
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
