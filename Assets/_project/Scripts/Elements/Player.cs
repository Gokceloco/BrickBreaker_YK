using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    void Update()
    {
        if (gameDirector.gameState != GameState.GamePlay)
        {
            return;
        }

        var xPos = Input.mousePosition.x / 1080 * 4 - 2;

        xPos = Mathf.Clamp(xPos, -2f, 2f);

        transform.position = new Vector3(xPos, -4f, 0);
    }
}