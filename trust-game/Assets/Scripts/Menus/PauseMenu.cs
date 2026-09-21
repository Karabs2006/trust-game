using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;

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

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale =1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
