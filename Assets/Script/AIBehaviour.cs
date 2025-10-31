using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
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
            if (agent.isActiveAndEnabled && agent.isOnNavMesh)
            {
                agent.SetDestination(player.position);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;

            // Change color to player's color
            playerRenderer = player.GetComponentInChildren<Renderer>();
            if (playerRenderer != null && enemyRenderer != null)
            {
                enemyRenderer.material.color = playerRenderer.material.color;
            }

            // Begin following permanently
            shouldFollow = true;
        }
    }
}
