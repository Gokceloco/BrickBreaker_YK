using DG.Tweening;
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public FailUI failUI;
    public WinUI winUI;

    public void StartGameButtonPressed()
    {
        mainMenu.Hide();
        gameDirector.RestartLevel();
    }
    public void RetryButtonPressed()
    {
        failUI.Hide();
        gameDirector.RestartLevel();
    }
    public void NextLevelButtonPressed()
    {
        winUI.Hide();
        gameDirector.LoadNextLevel();
    }
    public void ShowMainMenu()
    {
        mainMenu.Show();
        failUI.Hide();
        winUI.Hide();
    }
    public void ShowFailUI()
    {
        failUI.Show();
    }
    public void ShowWinUI()
    {
        winUI.Show();
    }
}
