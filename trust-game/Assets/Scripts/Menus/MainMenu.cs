using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public DialogueController cutscene;
    public Button evacuate;
    public GameObject credits;
    private string nextSceneName = "SampleScene";
    [HideInInspector] public bool mainMenuActive;
   
    public void Start()
    {
        mainMenuActive = true;
    }
    public void Play()
    {
        mainMenu.SetActive(false);
        cutscene.StartDialogue();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        mainMenuActive = false;
      SceneManager.LoadScene(nextSceneName);  
    }

    public void Credits()
    {
       credits.SetActive(true); 
    }

    public void Back()
    {
        credits.SetActive(false);
    }
}
