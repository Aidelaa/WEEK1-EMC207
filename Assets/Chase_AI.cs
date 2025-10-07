using UnityEngine;
using UnityEngine.AI;

public class Chase_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPos.position);
    }
}
