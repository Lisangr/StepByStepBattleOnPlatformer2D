using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private Dictionary<int, GameObject> enemies = new Dictionary<int, GameObject>();
    private int enemyID;

    void Start()
    {   
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int id = i;
            InstantiateEnemy(id);
        }

        enemyID = PlayerPrefs.GetInt("EnemyID");
        StartCoroutine(RemoveEnemy(enemyID));
    }
    void InstantiateEnemy(int id)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoints[id].position, Quaternion.identity);
        enemyInstance.name = $"Enemy_{id}";
        enemyInstance.GetComponent<Enemy>().enemyID = id;
        enemies.Add(id, enemyInstance);
    }
    public IEnumerator RemoveEnemy(int id)
    {
        yield return new WaitForSeconds(.2f);

        int i = 1;
        while (PlayerPrefs.HasKey("EnemyID" + i))
        {
            int enemyId = PlayerPrefs.GetInt("EnemyID" + i);

            GameObject enemyToDelete = GameObject.Find($"Enemy_{enemyId}");
            if (enemyToDelete != null)
            {
                enemies.Remove(enemyId);
                Destroy(enemyToDelete);
            }
            i++;
        }
    }    
}