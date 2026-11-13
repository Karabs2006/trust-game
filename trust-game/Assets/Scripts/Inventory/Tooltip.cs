using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;
public class Tooltip : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{   
    GameObject tooltipObj;
    public TMP_Text toolText;
    public String toolDescription;
    public Image background;
    

    void Awake()
    {   
        tooltipObj = GameObject.Find("TooltipObj");
        toolText = tooltipObj.GetComponentInChildren<TMP_Text>();
        background = tooltipObj.GetComponentInChildren<Image>();

        background.enabled = false;
        toolText.text = "";

    }

    public void SetMessage(string message)
    {
        toolText.text = message;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        SetMessage(toolDescription);
        background.enabled = true;

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {   

        background.enabled = false;  
        toolText.text = ""; 
    }
}
