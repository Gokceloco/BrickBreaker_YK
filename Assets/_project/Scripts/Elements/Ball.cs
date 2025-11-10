using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private LevelManager _levelManager;

    public float speed;

    private Vector3 _dir;

    public float xDirectionMultiplier;

    private Rigidbody2D _rb;

    public void StartBall(LevelManager levelManager)
    {
        _levelManager = levelManager;
        _dir = new Vector3(Random.Range(-.5f, .5f),1,0);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocity = _dir.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _dir = Vector3.Reflect(_dir, collision.contacts[0].normal);
        var color = Color.white;

        if (collision.gameObject.CompareTag("Bottom"))
        {
            _levelManager.LevelFailed();
            color = Color.red;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetHit(1);
            _levelManager.gameDirector.audioManager.PlayBrickHitAS();
            color = Color.yellow;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            var xOffset = transform.position.x - collision.transform.position.x;
            _dir.x = xOffset * xDirectionMultiplier;
            color = new Color(0,.5f,1);
        }

        _levelManager.gameDirector.fXManager.PlayImpactPS(collision.contacts[0].point, collision.contacts[0].normal, color);
        _levelManager.gameDirector.audioManager.PlayBounceAS();
    }

    public void StopBall()
    {
        _dir = Vector3.zero;
        transform.DOScale(0, .2f).SetEase(Ease.InBack);
    }
}
