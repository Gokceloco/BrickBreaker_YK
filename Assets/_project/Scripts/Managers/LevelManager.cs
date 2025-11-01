using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    public int levelNo;

    public Ball ballPrefab;

    private Ball _currentBall;
    private Level _currentLevel;

    public void RestartLevel()
    {
        DeleteOldBall();
        CreateNewBall();
        DeleteOldLevel();
        CreateNewLevel();
    }

    private void CreateNewLevel()
    {
        levelNo = Mathf.Clamp(levelNo, 1, levels.Count);
        _currentLevel = Instantiate(levels[levelNo-1]);
        _currentLevel.transform.position = Vector3.zero;
    }

    private void DeleteOldLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }

    private void CreateNewBall()
    {
        _currentBall = Instantiate(ballPrefab, transform);
        _currentBall.transform.position = new Vector3(0,-3,0);
    }

    private void DeleteOldBall()
    {
        if (_currentBall != null)
        {
            Destroy(_currentBall.gameObject);
        }
    }

    public void LevelFailed()
    {
        Invoke(nameof(RestartLevel), 1);
    }
}
