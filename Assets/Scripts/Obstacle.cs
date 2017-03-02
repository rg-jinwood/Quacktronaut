using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public Vector2 velocity;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
