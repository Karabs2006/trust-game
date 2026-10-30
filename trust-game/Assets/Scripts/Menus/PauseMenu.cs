using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject settingScreen;
    public GameObject keyBind;
    public Wrench wrench;

    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
           pausePanel.SetActive(true); 
            Time.timeScale =0;
            isPaused = true;
        }
        else if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale =1; 
            isPaused = false;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale =1; 
        isPaused = false; 
    }

    public void Restart()
    {   
        wrench.usedOnce = false;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale =1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        settingScreen.SetActive(false);
        keyBind.SetActive(false);
    }

    public void Keybinds()
    {
        keyBind.SetActive(true);
    }
    public void Settings()
    {
        settingScreen.SetActive(true);
    }
}
