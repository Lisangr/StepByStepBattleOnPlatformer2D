using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    public void TakeDamageForPlayer(int heal)
    {

        if (player != null)
        {
            player.currentHP += heal;

            if (player.currentHP <= 0)
            {
                Destroy(player.gameObject);
            }
        }
    }

    public void TakeDamageForEnemy(int heal)
    {

        if (enemy != null)
        {
            enemy.currentHP += heal;

            if (enemy.currentHP <= 0)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
