using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject startMenuPanel;
    public GameObject aboutMenuPanel;

    [Header("About Info")]
    public Text aboutInfoText;

    [Header("Button Actions")]
    public string puzzleSceneName = "PuzzleScene";
    public string dartSceneName = "DartScene";
    public string mainMenuSceneName = "MainMenuScene";  // Main Menu Scene Name

    void Start()
    {
        ShowMainMenu(); // Start with the main menu
    }

    // Show the main menu
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        startMenuPanel.SetActive(false);
        aboutMenuPanel.SetActive(false);
    }

    // Show the start menu
    public void ShowStartMenu()
    {
        mainMenuPanel.SetActive(false);
        startMenuPanel.SetActive(true);
        aboutMenuPanel.SetActive(false);
    }

    // Show the about menu
    public void ShowAboutMenu()
    {
        mainMenuPanel.SetActive(false);
        startMenuPanel.SetActive(false);
        aboutMenuPanel.SetActive(true);
    }

    // Load the PuzzleScene
    public void LoadPuzzleScene()
    {
        SceneManager.LoadScene(puzzleSceneName);
    }

    // Load the DartScene
    public void LoadDartScene()
    {
        SceneManager.LoadScene(dartSceneName);
    }

    // Load the Main Menu Scene
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName); // Load Main Menu Scene
    }

    // Reset the current scene
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Exit the game
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
