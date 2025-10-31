using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 5;
    public float spawnRadius = 10f;

    public Transform player;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0; // keep them on ground level

            GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            enemy.tag = "Enemy";
        }
    }
}
