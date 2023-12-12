using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.instance.PauseAllMusic();
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.instance.UnPauseAllMusic();
        isPaused = false;
    }

    public void quitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void restartGame()
    {
        Debug.Log("Restart Game!");
        Time.timeScale = 1f;
        GameManager.instance.RestartGame();
    }
}
