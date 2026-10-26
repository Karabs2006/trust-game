using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PuzzleThree : MonoBehaviour
{   
    
    public Color currentColor;
    private Image background;
    private Button button;
    public ColourTrack colourTrack;
    

    void Start()
    {
        background = GetComponent<Image>();
        background.color = currentColor; 
        button = GetComponent<Button>();       
        button.onClick.AddListener(callColour);
    }

    void Update()
    {
        //button.onClick.AddListener(callColour);
    }

    void callColour()
    {
        //Debug.Log(currentColor);

        colourTrack.inputColours.Add(currentColor);

        if(colourTrack.inputColours.Count == 4)
        {
            colourTrack.inputList = string.Join(", ",colourTrack.inputColours.ConvertAll(colour =>

                colour == Color.red ? "Red" :
                colour == Color.blue ? "Blue" :
                colour == Color.green ? "Green" :
                colour == Color.yellow ? "Yellow" : "Unknown"
            
            ) );



            //Debug.Log("Input list:" + colourTrack.inputList);

            if(colourTrack.inputList == colourTrack.setList)
            {
                Debug.Log("YOU MATCHED THE COLOURS!");
                colourTrack.randomise();
            }
            else
            {
                Debug.Log("YOU'RE A DINGUS THEY DONT MATCH!");
                colourTrack.randomise();
            }
        }
    }

    IEnumerator flashColours()
    {
        yield return new WaitForSeconds(1f);
    }
}
