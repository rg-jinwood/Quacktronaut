using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Vector2 JumpForce = new Vector2(0, 300);
    public ObstacleSpawner spawner;

    void Update() {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        var player = GetComponent<Rigidbody2D>();
        
        if (Input.GetKeyDown("up"))
        {
            player.velocity = Vector2.zero;
            player.AddForce(JumpForce);
        }

        var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Word Obstacle")
            return;

        if (other.gameObject.tag == "Untagged")
            return;

        Die();
    }

    void Die()
    {
        PlayerState.IsAlive = false;
        Time.timeScale = 0f;
    }
}
