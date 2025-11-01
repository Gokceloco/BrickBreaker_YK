using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public float timeScale;
    public LevelManager levelManager;

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

    private void RestartLevel()
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

}
