using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Vector3 _dir;

    void Start()
    {        
        _dir = new Vector3(Random.Range(-.5f, .5f),1,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _dir = Vector3.Reflect(_dir, collision.contacts[0].normal);

        if (collision.gameObject.CompareTag("Bottom"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetHit(1);
        }        
    }
}
