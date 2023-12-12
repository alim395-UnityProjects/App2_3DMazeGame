using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGameMenu : MonoBehaviour
{
    UIDocument uiEndGame;
    Label currentPlayerTime;
    TextField initialInputField;
    Button submitButton;

    private void OnEnable()
    {
        uiEndGame = GetComponent<UIDocument>();

        currentPlayerTime = uiEndGame.rootVisualElement.Q<Label>(name = "CurrentPlayerTime");

        if(GameManager.instance != null)
        {
            currentPlayerTime.text = "Completed in: " + GameManager.instance.getPlayerTime();
        }

        initialInputField = uiEndGame.rootVisualElement.Q<TextField>();
        
        submitButton = uiEndGame.rootVisualElement.Q<Button>();
        submitButton.RegisterCallback<ClickEvent>(OnSubmit);
    }

    public void OnSubmit(ClickEvent evt)
    {
        Debug.Log("Submit Button Clicked!");
        if(GameManager.instance != null )
        {
            if (initialInputField.value != null)
            {
                GameManager.instance.setPlayerInitials(initialInputField.value);
                Debug.Log("Initials Saved!");
                SceneManager.LoadScene("Leader");
            }
        }
    }
}
