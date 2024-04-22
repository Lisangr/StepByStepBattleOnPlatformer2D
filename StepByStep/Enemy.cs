using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int MaxHP;
    public int damage;
    public string Scene;
    public Camera cameraToAssign;
    public int enemyID;
    public delegate void AttackFunction();
    private AttackFunction[] attackFunctions = new AttackFunction[4];
    //private EnemyManager enemyManager;
    private Damage damageScript;

    public void Awake()
    {
        PlayerPrefs.DeleteAll();
        damageScript = FindObjectOfType<Damage>().GetComponent<Damage>();
        //enemyManager = FindObjectOfType<EnemyManager>();

        attackFunctions[0] = () => damageScript.TakeDamageForPlayer(damage);
        attackFunctions[1] = () => damageScript.TakeDamageForPlayer(damage);
        attackFunctions[2] = () => damageScript.TakeDamageForPlayer(damage);
        attackFunctions[3] = () => damageScript.TakeDamageForPlayer(damage);
    }

    public void GenerateRandomAttack()
    {
        int randomValue = Random.Range(0, 400);
        int functionIndex = randomValue / 100;
        attackFunctions[functionIndex]();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //enemyManager.SetCurrentEnemy(this);
            int i = 1;
            while (PlayerPrefs.HasKey("EnemyID" + i))
            {
                i++;
            }
            PlayerPrefs.SetInt("EnemyID" + i, enemyID);
            SceneManager.LoadScene("BattleSceneOther");
        }
    }
}