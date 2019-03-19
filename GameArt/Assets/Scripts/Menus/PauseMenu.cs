using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //public to check if game is paused from other scripts
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    //Loading menu from the menu button
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu... No menu yet");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
