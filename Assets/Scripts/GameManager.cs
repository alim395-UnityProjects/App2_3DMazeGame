using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    AudioManager audioManager;
    StopWatch stopWatch;

    bool gamePlayed = false;
    string currentPlayerInitials = string.Empty;
    string currentPlayerTime = string.Empty;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioManager = FindObjectOfType<AudioManager>();
        stopWatch = FindObjectOfType<StopWatch>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        stopWatch.startStopWatch();
        audioManager.Play("Theme");
    }

    public void EndGame()
    {
        gamePlayed = true;
        stopWatch.stopStopWatch();
        audioManager.StopAllMusic();
        currentPlayerTime = stopWatch.getCurrentTime();
        if (gamePlayed)
        {
            SceneManager.LoadScene("EndGame");
            audioManager.Play("GameCompleted");
        }
        else
        {
            SceneManager.LoadScene("Leader");
        }
    }

    public void RestartGame()
    {
        gamePlayed = false;
        stopWatch.stopStopWatch();
        audioManager.StopAllMusic();
        SceneManager.LoadScene("MainGame");
        Awake();
        Start();
    }

    public void setPlayerInitials(string initials)
    {
        currentPlayerInitials=initials;
    }

    public string getPlayerInitials()
    {
        return currentPlayerInitials;
    }

    public void setPlayerTime(string time)
    {
        currentPlayerTime = time;
    }

    public string getPlayerTime()
    {
        return currentPlayerTime;
    }
}
