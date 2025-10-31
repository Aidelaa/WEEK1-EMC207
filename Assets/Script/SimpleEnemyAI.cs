using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Renderer enemyRenderer;
    private bool shouldFollow = false;
    private Transform player;
    private Renderer playerRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (shouldFollow && player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get player references
            player = collision.transform;
            playerRenderer = player.GetComponentInChildren<Renderer>();

            if (playerRenderer != null && enemyRenderer != null)
            {
                // Change enemy color to match player
                enemyRenderer.material.color = playerRenderer.material.color;
            }

            // Start following the player permanently
            shouldFollow = true;
        }
    }
}
