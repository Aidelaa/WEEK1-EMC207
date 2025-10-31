using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    [HideInInspector] public Transform player;
    [HideInInspector] public bool isFollowing = false;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isFollowing && player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
        }
    }
}
