using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public string gameSceneName;
    public string mainMenuSceneName;

    // Remove gameState reference as we will use singleton

    // private bool isGamePaused; removed as we will use GameStateManager

    private void Start()
    {
        // Time.timeScale set in GameStateManager
        pauseMenu.SetActive(false);

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == mainMenuSceneName)
        {
            GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.MainMenu);
            mainMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.InGame);
       // SceneManager.LoadScene(gameSceneName);
        mainMenu.SetActive(false);

    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        // Use GameStateManager instead of isGamePaused
        if (GameStateManager.Instance.currentGameState == GameStateManager.GameState.MainMenu)
        {
            GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.Paused);
            pauseMenu.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.MainMenu);
        SceneManager.LoadScene(mainMenuSceneName);
        pauseMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        // Use GameStateManager instead of isGamePaused
        if (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Paused)
        {
           // GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.InGame);
            GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.MainMenu);
            pauseMenu.SetActive(false);

        }
    }

    public void LoadCurrentScene()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.InGame);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
