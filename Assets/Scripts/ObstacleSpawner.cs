using Assets.Scripts.Helpers;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public Vector3 SpawnLocation;
    public List<GameObject> SpawnableObjects;
    bool isSpawning = false;
    public float minTime = 1.0f;
    public float maxTime = 3.0f;

    private Random random = new Random();
    private RevisionModel revisions;

    private void Start()
    {
        var token = PlayerPrefs.GetString("token");
        StartCoroutine(RevisionHelper.GetLatestRevision(token, GetRevisions));
    }

    private void GetRevisions(RevisionModel model)
    {
        revisions = model;
    }

    private void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, SpawnableObjects.Count);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(minTime, maxTime)));
            //InvokeRepeating("SpawnObject", 1, 1);}
        }
    }

    private bool Spawnable()
    {
        var x = GameObject.FindGameObjectsWithTag("Obstacle");
        return GameObject.FindGameObjectsWithTag("Obstacle").Length < 3;
    }

    private IEnumerator SpawnObject(int index, float seconds)
    {
            if (Spawnable())
            {
                Debug.Log("Waiting for " + seconds + " seconds");

                yield return new WaitForSeconds(seconds);
                var obj = SpawnableObjects[Random.Range(0, SpawnableObjects.Count)];
                Instantiate(obj, SpawnLocation, Quaternion.identity);

                //We've spawned, so now we could start another spawn     
                isSpawning = false;
            } 
        //combine spawnable objects from SpawnableObjects
        //with whatever is fetched from API
    }
}
