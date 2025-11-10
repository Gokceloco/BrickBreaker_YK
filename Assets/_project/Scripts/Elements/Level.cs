using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    private LevelManager _levelManager;

    private List<Brick> _bricks = new List<Brick>();

    public void StartLevel(LevelManager levelManager)
    {
        _levelManager = levelManager;
        _bricks = GetComponentsInChildren<Brick>().ToList();
    }

    public void BrickDestroyed(Brick brick)
    {
        _bricks.Remove(brick);
        if (_bricks.Count <= 0)
        {
            _levelManager.LevelCompleted();
        }
        _levelManager.gameDirector.fXManager.PlayBrickDestroyPS(brick.transform.position);
    }
}
