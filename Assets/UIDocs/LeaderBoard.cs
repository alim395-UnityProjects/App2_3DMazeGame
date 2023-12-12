using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LeaderBoard : MonoBehaviour
{
    UIDocument uiLeaderboard;
    VisualElement leaderboardContent;
    VisualElement leaderboardButtons;

    Button menuButton;
    Button restartButton;

    List<ScoreData> scoreList = new List<ScoreData>();
    string scoreListPATH;

    private void Awake()
    {
        scoreListPATH = Application.persistentDataPath + "/scoreDataFile.json";
    }

    private void OnEnable()
    {
        uiLeaderboard = GetComponent<UIDocument>();

        leaderboardContent = uiLeaderboard.rootVisualElement.Q<VisualElement>(name = "Content");
        leaderboardButtons = uiLeaderboard.rootVisualElement.Q<VisualElement>(name = "Buttons");

        menuButton = leaderboardButtons.Q<Button>(name = "MenuButton");
        menuButton.RegisterCallback<ClickEvent>(OnMenu);

        if(GameManager.instance != null)
        {
            restartButton = new Button();
            restartButton.text = "Restart";
            restartButton.AddToClassList("LeaderboardButton");
            leaderboardButtons.Add(restartButton);
            restartButton.RegisterCallback<ClickEvent>(OnRestart);
        }

        if (File.Exists(scoreListPATH))
        {
            scoreList = FileHandler.ReadListFromJSON<ScoreData>("scoreDataFile.json");
            if (GameManager.instance != null)
            {
                scoreList.Add(new ScoreData(GameManager.instance.getPlayerInitials(), GameManager.instance.getPlayerTime()));
            }
            FileHandler.SaveToJSON(scoreList, "scoreDataFile.json");
        }
        else
        {
            if (GameManager.instance != null)
            {
                ScoreData currentPlayerScore = new ScoreData(GameManager.instance.getPlayerInitials(), GameManager.instance.getPlayerTime());
                scoreList.Add(currentPlayerScore);
            }
            FileHandler.SaveToJSON(scoreList, "scoreDataFile.json");
        }

        if(scoreList.Count > 1)
        {
            scoreList.Sort((left, right) => left.playerTime.CompareTo(right.playerTime));
        }

        foreach (ScoreData s in scoreList) 
        {
            VisualElement leaderEntry = createLeaderboardEntry(s.playerInitials, s.playerTime);
            leaderboardContent.Add(leaderEntry);
        }
    }

    private VisualElement createLeaderboardEntry(string name, string time)
    {
        VisualElement leaderboardEntry = new VisualElement();
        leaderboardEntry.AddToClassList("LeaderboardEntry");

        Label playerName = new Label(name);
        leaderboardEntry.Add(playerName);

        Label playerTime = new Label(time);
        leaderboardEntry.Add(playerTime);

        return leaderboardEntry;
    }

    private void OnMenu(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRestart(ClickEvent evt)
    {
        GameManager.instance.RestartGame();
    }
}
