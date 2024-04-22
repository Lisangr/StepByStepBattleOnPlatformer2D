using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    
    public void TakeDamageForPlayer(int damage)
    {
        
        if (player != null)
        {            
            player.currentHP -= damage;

            if (player.currentHP <= 0)
            {
                Destroy(player.gameObject);
            }
        }
    }

    public void TakeDamageForEnemy(int damage)
    {
        enemy.currentHP -= damage;

        if (enemy.currentHP <= 0)
        {
            Destroy(enemy.gameObject);
            EnemyManager.Instance.EndBattleScene();
            //EnemyManager.Instance.DestroyCurrentEnemy(enemy.enemyID);
        }
    }
}