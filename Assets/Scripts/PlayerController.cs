using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 JumpForce = new Vector2(0, 300);

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        var player = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown("space"))
        {
            player.velocity = Vector2.zero;
            player.AddForce(JumpForce);
        }
	}
}
