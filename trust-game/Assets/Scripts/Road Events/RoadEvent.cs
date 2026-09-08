using UnityEngine;

public class RoadEvent : MonoBehaviour
{

    public GameObject minigame;
    void Start()
    {
        //minigame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartEvent()
    {
        Time.timeScale = 0f;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartEvent();
        }
    }
}

