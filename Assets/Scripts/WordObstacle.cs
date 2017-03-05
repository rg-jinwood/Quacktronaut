using UnityEngine;

public class WordObstacle : MonoBehaviour
{
    public Vector2 velocity;
    private ObstacleSpawner spawner;

    void Start()
    {
        var spawnerObject = GameObject.FindWithTag("GameController");
        spawner = spawnerObject.GetComponent<ObstacleSpawner>();
        GetComponent<Rigidbody2D>().velocity = velocity;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject); //just incase
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Despawner") //don't destroy if its the player's collider
            Destroy(gameObject);

        if (other.gameObject.tag == "Player")
        {
            spawner.CheckWordCollision(gameObject);
        }

    }
}
