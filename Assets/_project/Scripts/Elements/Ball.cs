using UnityEngine;

public class Ball : MonoBehaviour
{
    public LevelManager levelManager;
    public float speed;

    private Vector3 _dir;

    public float xDirectionMultiplier;

    private Rigidbody2D _rb;

    void Start()
    {        
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

        if (collision.gameObject.CompareTag("Bottom"))
        {
            GetComponentInParent<LevelManager>().LevelFailed();

            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetHit(1);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            var xOffset = transform.position.x - collision.transform.position.x;
            _dir.x = xOffset * xDirectionMultiplier;
        }
    }
}
