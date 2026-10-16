using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public DialogueController cutscene;
    public Button evacuate;
    private string nextSceneName = "SampleScene";
    
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
      SceneManager.LoadScene(nextSceneName);  
    }
}
