using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public float timeScale;
    public GameState gameState;

    [Header("Managers")]
    public LevelManager levelManager;
    public AudioManager audioManager;
    public FXManager fXManager;
    public UIManager uIManager;


    private void Start()
    {
        uIManager.ShowMainMenu();
        gameState = GameState.MainMenu;
    }

    private void Update()
    {
        Time.timeScale = timeScale;
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadPreviousLevel();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadNextLevel();
        }
    }

    public void RestartLevel()
    {
        gameState = GameState.GamePlay;
        levelManager.RestartLevel();
    }

    public void LoadNextLevel()
    {
        levelManager.levelNo++;
        RestartLevel();
    }

    private void LoadPreviousLevel()
    {
        levelManager.levelNo--;
        RestartLevel();
    }

    public void LevelCompleted()
    {
        audioManager.PlayVictoryAS();
        gameState = GameState.Win;
        uIManager.ShowWinUI();
    }

    public void LevelFailed()
    {
        audioManager.PlayFailAS();
        gameState = GameState.Fail;
        uIManager.ShowFailUI();
    }
}

public enum GameState
{
    MainMenu,
    GamePlay,
    Win,
    Fail,
}