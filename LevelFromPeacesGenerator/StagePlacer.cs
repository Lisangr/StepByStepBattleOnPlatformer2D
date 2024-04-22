using System.Collections.Generic;
using UnityEngine;

public class StagePlacer : MonoBehaviour
{/*
    public Transform player;
    public Stage[] stagePrefab;
    public Stage firstStage;

    private List<Stage> spawnedStage = new List<Stage>();
    private void Start()
    {
        spawnedStage.Add(firstStage);        
    }
    private void Update()
    {
        if (player != null && (player.position.x > spawnedStage[spawnedStage.Count - 1].end.position.x - 5))
        {
            SpawnStage();
        }
    }
    private void SpawnStage()
    {
        Stage newStage = Instantiate(stagePrefab[Random.Range(0, stagePrefab.Length)]);
        newStage.transform.position = spawnedStage[spawnedStage.Count - 1].end.position - newStage.begin.localPosition;
        spawnedStage.Add(newStage);
       
        if (spawnedStage.Count >= 4)
        {
            Destroy(spawnedStage[1].gameObject);
            spawnedStage.RemoveAt(0);
        }
    }*/
    private static StagePlacer _instance;

    public Transform player;
    public Stage[] stagePrefab;
    public Stage firstStage;

    private List<Stage> spawnedStage = new List<Stage>();


    public static StagePlacer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StagePlacer>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("StagePlacer");
                    _instance = singletonObject.AddComponent<StagePlacer>();
                }
            }
            return _instance;
        }
    }

    private StagePlacer() { }

    private void Start()
    {
        spawnedStage.Add(firstStage);
    }

    private void Update()
    {
        if (player != null && (player.position.x > spawnedStage[spawnedStage.Count - 1].end.position.x - 5))
        {
            SpawnStage();
        }
    }

    private void SpawnStage()
    {
        Stage newStage = Instantiate(stagePrefab[Random.Range(0, stagePrefab.Length)]);
        newStage.transform.position = spawnedStage[spawnedStage.Count - 1].end.position - newStage.begin.localPosition;
        spawnedStage.Add(newStage);

        if (spawnedStage.Count >= 4)
        {
            Destroy(spawnedStage[1].gameObject);
            spawnedStage.RemoveAt(0);
        }
    }
}
