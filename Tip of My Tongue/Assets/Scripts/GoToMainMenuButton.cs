using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMainMenuButton : MonoBehaviour
{
    public Button mainMenuButton;
    public string mainMenuSceneName = "mainMenu";

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
