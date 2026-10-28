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

    public GameObject indicatorParent;

    List<Color> criteriaColours = new List<Color>{};

    public List<Color> inputColours = new List<Color>{};


    public float coolDown = 0.5f;
    public Image image;
    public string setList;
    public string inputList;
    public int indicatorIndex = 0;
    public List<Image> playerIndicators = new List<Image>(); //List of images to show players what colour order they inputed
    
    void Start()
    {
        Image[] imagesArray = indicatorParent.GetComponentsInChildren<Image>();
        playerIndicators = new List<Image>(imagesArray);

        //image = GetComponent<Image>();
        //StartCoroutine(flashColours());
        image.enabled = false;
        //randomise();
        
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
            image.color = colors[randomIndex];

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
            image.enabled = true;
            StartCoroutine(flashColours());

    }

    IEnumerator flashColours()
    {   
        
        foreach (Color colour in criteriaColours)
        {
            image.color = colour;
            yield return new WaitForSecondsRealtime(coolDown);
        }

        image.enabled = false;
    }

}
