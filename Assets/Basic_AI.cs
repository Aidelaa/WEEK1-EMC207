using UnityEngine;
using UnityEngine.AI;

public class Basic_AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform pointB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(pointB.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("DestinationReached");
        }
    }
}
