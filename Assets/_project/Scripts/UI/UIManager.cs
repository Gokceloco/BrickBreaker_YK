using DG.Tweening;
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public LoseUI loseUI;

    public void StartGameButtonPressed()
    {
        mainMenu.Hide();
        gameDirector.RestartLevel();
    }
    public void RetryButtonPressed()
    {
        loseUI.Hide();
        gameDirector.RestartLevel();
    }

    public void ShowMainMenu()
    {
        mainMenu.Show();
        loseUI.Hide();
    }

    public void ShowFailUI()
    {
        loseUI.Show();
    }
}
