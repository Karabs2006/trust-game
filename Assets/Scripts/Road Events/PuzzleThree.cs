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
    public PuzzleThreeTimer puzzleThreeTimer;
    

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
        colourTrack.playerIndicators[colourTrack.indicatorIndex].color = currentColor;
        colourTrack.indicatorIndex++;
    

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
                puzzleThreeTimer.solvedInt++;
                puzzleThreeTimer.solvedText.text = $"{puzzleThreeTimer.solvedInt}";
                //StartCoroutine(flashColours(Color.green));
                ResetIndicators();
                
            }
            else
            {
                Debug.Log("YOU'RE A DINGUS THEY DONT MATCH!");
                colourTrack.randomise();
                //StartCoroutine(flashColours(Color.red));
                ResetIndicators();
        
            }
        }
    }

    public void ResetIndicators()
    {
        colourTrack.indicatorIndex = 0;
        colourTrack.inputColours.Clear();
        colourTrack.inputList = "";
    
        foreach(Image image in colourTrack.playerIndicators)
        {
            image.color = Color.white;
        }
    }

    IEnumerator flashColours(Color color)
    {
        foreach(Image image in colourTrack.playerIndicators )
        {
            image.color = color;
            yield return new WaitForSeconds(0.4f);
            image.color = Color.white;
        }
        
    }
}
