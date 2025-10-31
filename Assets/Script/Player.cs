using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public string enemyTag = "Enemy";   // tag used for all enemies
    public float sightRange = 5f;       // distance for color change
    private Renderer playerRenderer;    // reference to player's material

    void Start()
    {
        // Get player's renderer
        playerRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        // Find all enemies by tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if enemy is within range
            if (distanceToEnemy <= sightRange)
            {
                Renderer enemyRenderer = enemy.GetComponentInChildren<Renderer>();

                if (enemyRenderer != null && playerRenderer != null)
                {
                    enemyRenderer.material.color = playerRenderer.material.color;
                }

                // Optional: make enemy follow player if it has NavMeshAgent
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.SetDestination(transform.position);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
