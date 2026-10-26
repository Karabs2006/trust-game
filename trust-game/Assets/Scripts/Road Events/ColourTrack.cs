using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ColourTrack : MonoBehaviour
{
    List<Color> colors = new List<Color>{

        Color.red,
        Color.blue,
        Color.green,
        Color.yellow
    };

    List<Color> criteriaColours = new List<Color>{};

    public float coolDown;

    public Image image;
    
    void Start()
    {
        //image = GetComponent<Image>();
        StartCoroutine(flashColours());
        randomise();
    }

    
    void Update()
    {
        
    }

    void randomise()
    {
        criteriaColours.Clear();
        criteriaColours.AddRange(colors);

        for (int i = 0; i < criteriaColours.Count; i++)
        {
            int randomIndex = Random.Range(i, criteriaColours.Count);

            Color temp = criteriaColours[i];
            criteriaColours[i] = criteriaColours[randomIndex];
            criteriaColours[randomIndex] = temp;
        }

        foreach (Color colour in criteriaColours)
        {
            Debug.Log(string.Join(", ", criteriaColours));
        }
    }

    IEnumerator flashColours()
    {   
        while(true)
        {
            int index = Random.Range(0,colors.Count);
            image.color = colors[index];

             //Debug.Log(colors[index]);
            yield return new WaitForSeconds(1f);
        }
    }
}
