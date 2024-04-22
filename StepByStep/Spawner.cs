using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform player;
    private Transform enemy;
    public Transform playerPosition;
    public Transform enemyPosition;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        enemy = FindObjectOfType<Enemy>().transform;

        player.transform.position = playerPosition.position;
        enemy.transform.position = enemyPosition.position;
    }
}
