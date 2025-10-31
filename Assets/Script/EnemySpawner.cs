using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // assign your capsule prefab here
    public int enemyCount = 5;     // how many to spawn
    public float spawnRadius = 10f; // how far around the player or center they appear

    public Transform player; // reference to player position

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Pick a random position near player or spawner
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0; // keep them on ground level

            GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

            // Tag and position safety
            enemy.tag = "Enemy";
        }
    }
}
