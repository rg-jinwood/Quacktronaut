using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFloat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.007f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -1 * Time.deltaTime);
    }
}
