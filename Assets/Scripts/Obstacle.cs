using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 velocity;

    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
	

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
