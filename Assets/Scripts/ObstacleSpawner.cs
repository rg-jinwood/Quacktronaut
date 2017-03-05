using Assets.Scripts.Handlers;
using Assets.Scripts.Helpers;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour {

    public Vector3 spawnLocation;
    public List<GameObject> spawnableObjects;
    bool isSpawning = false;
    public float minTime = 1.0f;
    public float maxTime = 2.0f;
    public Text score;

    private Random random = new Random();
    private List<RevisionDatum> revisions;
    private RevisionDatum selectedRevision;
    private float notSpawningCounter;
    private int scoreCount;

    public void CheckWordCollision(GameObject wordObject)
    {
        var selectedWord = selectedRevision.variant.text;
        var selectedAnswer = selectedRevision.translation.text;
        var possibleWrongAnswers = selectedRevision.wrong_answers;

        foreach (var component in wordObject.GetComponentsInChildren<Text>())
        {
            var correct = RevisionAnswerHandler.IsCorrect(selectedAnswer, possibleWrongAnswers, component);

            if (correct)
            {
                revisions.Remove(selectedRevision);
                selectedRevision = revisions.FirstOrDefault();
                scoreCount += 1;
            }
            else
            {
                selectedRevision.wrong_answers.Remove(component.text);
            }
        }
        Destroy(wordObject);
    }

    private void Start()
    {
        scoreCount = 0;
        var token = PlayerPrefs.GetString("token");
        if(revisions == null)
            StartCoroutine(RevisionHelper.GetLatestRevision(token, GetRevisions));
    }

    private void GetRevisions(RevisionModel model)
    {
        revisions = model.data;
        selectedRevision = revisions.FirstOrDefault();
    }

    private void Update()
    {
        score.text = scoreCount.ToString(); ;
        if (!isSpawning)
        {
            notSpawningCounter = 0f;
            isSpawning = true;
            StartCoroutine(SpawnObject(Random.Range(minTime, maxTime)));
        }
        if (notSpawningCounter > 2) //ensure we don't get stuck on not spawning
            isSpawning = false;
        else
        {
            notSpawningCounter += Time.deltaTime;
        }
    }

    private bool Spawnable()
    {
        return GameObject.FindGameObjectsWithTag("Obstacle").Length < 4;
    }

    private bool SceneDoesntContainWordObstacle()
    {
        return GameObject.FindGameObjectsWithTag("Word Obstacle").Length == 0;
    }

    private IEnumerator SpawnObject(float seconds)
    {
        if (Spawnable())
        {
            yield return new WaitForSeconds(seconds);
            var obj = spawnableObjects.FirstOrDefault(x => x.tag == "Obstacle");
            spawnLocation = new Vector3(12, Random.Range(-8, 12), 0);

            if (selectedRevision != null && SceneDoesntContainWordObstacle())
            {
                if(Random.Range(0,2) == 0)
                {
                    spawnLocation = new Vector3(12, 12, 0);
                    obj = spawnableObjects.FirstOrDefault(x => x.tag == "Word Obstacle");
                    foreach(var component in obj.GetComponentsInChildren<Text>())
                    {
                        if (component.name == "Word")
                            component.text = selectedRevision.variant.text;
                        if (component.name == "Answer")
                        {
                            var answer = RevisionAnswerHandler.GenerateAnswer(selectedRevision);
                            component.text = answer;
                        }
                    }
                }
            }
            //if the scene contains a word obstacle, don't spawn any standard obstacles at that height
            if (GameObject.FindGameObjectsWithTag("Word Obstacle").Length > 0) 
                spawnLocation = new Vector3(12, Random.Range(-8, 8), 0);

            Instantiate(obj, spawnLocation, Quaternion.identity);

            //We've spawned, so now we could start another spawn     
            isSpawning = false;
        }
    }
}
