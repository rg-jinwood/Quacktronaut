using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject ObstaclePrefab;
    public Vector3 SpawnLocation;


	// Use this for initialization
	void Start () {
        Instantiate(ObstaclePrefab, SpawnLocation, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
