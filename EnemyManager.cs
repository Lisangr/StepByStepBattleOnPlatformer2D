using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private Enemy currentEnemy;
    //private EnemySpawner enemySpawner;
    private static EnemyManager instance;
    /*private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }*/
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();

                if (instance == null)
                {
                    GameObject managerObject = new GameObject("EnemyManager");
                    instance = managerObject.AddComponent<EnemyManager>();
                    DontDestroyOnLoad(managerObject);
                }
            }
            return instance;
        }
    }


    public void SetCurrentEnemy(Enemy enemy)
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
        }

        currentEnemy = enemy;
    }
    
    public void DestroyCurrentEnemy(int id)
    {
        int enemyId = id;
        GameObject enemyToDelete = GameObject.Find($"Enemy_{enemyId}");
        Destroy(enemyToDelete);
    }
    public void EndBattleScene()
    {
        SceneManager.LoadScene("Demo");
    }
}