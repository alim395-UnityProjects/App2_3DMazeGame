using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play the Game!");
        SceneManager.LoadScene("MainGame");
    }

    public void LeadGame()
    {
        Debug.Log("Openning Leaderboard");
        SceneManager.LoadScene("Leader");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
