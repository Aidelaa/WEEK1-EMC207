using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerPos;
    public float sightRange;
    public float distanceToPlayer;
    public Transform pointA,pointB;
    public float attackRange;

    private Renderer enemyRenderer;
    private Renderer playerRenderer;
    private bool colorChanged = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position,playerPos.position);

        if (distanceToPlayer <= sightRange)
        {
            // Change color to player's color (only once)
            if (!colorChanged && playerRenderer != null)
            {
                enemyRenderer.material.color = playerRenderer.material.color;
                colorChanged = true;
            }

            // Optional: You can make the enemy follow the player too
            agent.SetDestination(playerPos.position);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
