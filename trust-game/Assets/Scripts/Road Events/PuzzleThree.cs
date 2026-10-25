using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleThree : MonoBehaviour
{   
    List<Color> colors = new List<Color>{

        Color.red,
        Color.blue,
        Color.green,
        Color.orange
    };

    public Color currentColor;
    float coolDown;

    private Image background;

    void Start()
    {
        background = GetComponent<Image>();
        background.color = currentColor;        
    }

    void Update()
    {
        
    }

    IEnumerator flashColours()
    {
        yield return new WaitForSeconds(1f);
    }
}
