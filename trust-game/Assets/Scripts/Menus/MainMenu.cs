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
    public Animator cutsceneAnim;
    private string nextSceneName = "SampleScene";
    [HideInInspector] public bool mainMenuActive;
   
    public void Start()
    {
        mainMenuActive = true;
        GetComponent<SoundEffectManager>();
    }
    public void Play()
    {
        cutsceneAnim.SetBool("isActive", true);
        mainMenu.SetActive(false);
        cutscene.StartDialogue();
        SoundEffectManager.Play("TV"); 
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
