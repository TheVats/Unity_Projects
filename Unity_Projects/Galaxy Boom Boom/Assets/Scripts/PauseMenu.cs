using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameisPaused = false;

    public GameObject pauseMenuUi;
    
     void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
     public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameisPaused = true;
    }
     public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Quitting The Game....");
        Application.Quit();
    }

}
