using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        InGame,
        Paused,
        GameOver,
        // Add any other states you need
    }

    public static GameStateManager Instance;
    public GameState currentGameState;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initial state
        ChangeGameState(GameState.MainMenu);
    }

    public void ChangeGameState(GameState newGameState)
    {
        currentGameState = newGameState;

        switch (currentGameState)
        {
            case GameState.MainMenu:
                // Operations needed in the MainMenu state
                break;
            case GameState.InGame:
                // Operations needed in the InGame state
                Time.timeScale = 1;
                break;
            case GameState.Paused:
                // Operations needed in the Paused state
                Time.timeScale = 0;
                break;
            case GameState.GameOver:
                // Operations needed in the GameOver state
                break;
                // Handle other states
        }
    }
}