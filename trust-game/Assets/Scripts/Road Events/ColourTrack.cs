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

    public List<Color> inputColours = new List<Color>{};

    public float coolDown;
    public Image image;

    public string setList;
    public string inputList;
    
    void Start()
    {
        //image = GetComponent<Image>();
        StartCoroutine(flashColours());
        randomise();
    }

    
    void Update()
    {
        
    }

    public void randomise()
    {   
        inputColours.Clear();
        criteriaColours.Clear();
        criteriaColours.AddRange(colors);

        for (int i = 0; i < criteriaColours.Count; i++)
        {
            int randomIndex = Random.Range(i, criteriaColours.Count);

            Color temp = criteriaColours[i];
            criteriaColours[i] = criteriaColours[randomIndex];
            criteriaColours[randomIndex] = temp;
        }

        
            setList = string.Join(", ", criteriaColours.ConvertAll(colour =>

                colour == Color.red ? "Red" :
                colour == Color.blue ? "Blue" :
                colour == Color.green ? "Green" :
                colour == Color.yellow ? "Yellow" : "Unknown"));

            Debug.Log(setList);

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
