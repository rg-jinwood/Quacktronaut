using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public Vector3 SpawnLocation;
    public List<GameObject> SpawnableObjects;

    private Random random = new Random();

	void FixedUpdate ()
    {
        var obj = SpawnableObjects[Random.Range(0, SpawnableObjects.Count)];

        if (Spawnable())
        {
            SpawnObject();
        }
    }

    private bool Spawnable()
    {
        return GameObject.FindGameObjectsWithTag("Obstacle").Length < 3;
    }

    private void SpawnObject()
    {
        //combine spawnable objects from SpawnableObjects
        //with whatever is fetched from API
    }
}
