using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public float timeScale;
    public LevelManager levelManager;

    public UIManager uIManager;

    private void Start()
    {
        uIManager.ShowMainMenu();
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
        levelManager.RestartLevel();
    }

    private void LoadNextLevel()
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
        Invoke(nameof(LoadNextLevel), 1);
    }

    public void LevelFailed()
    {
        uIManager.ShowFailUI();
    }
}
