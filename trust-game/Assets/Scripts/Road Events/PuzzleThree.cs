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
        Debug.Log(currentColor);
    }

    IEnumerator flashColours()
    {
        yield return new WaitForSeconds(1f);
    }
}
