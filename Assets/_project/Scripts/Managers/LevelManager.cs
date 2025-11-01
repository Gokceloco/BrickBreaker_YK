using JetBrains.Annotations;
using System;
using System.Xml.Serialization;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Ball ballPrefab;

    private Ball _currentBall;

    public void RestartLevel()
    {
        DeleteOldBall();
        CreateNewBall();
    }

    private void CreateNewBall()
    {
        _currentBall = Instantiate(ballPrefab);
        _currentBall.transform.position = new Vector3(0,-3,0);
    }

    private void DeleteOldBall()
    {
        if (_currentBall != null)
        {
            Destroy(_currentBall.gameObject);
        }
    }
}
