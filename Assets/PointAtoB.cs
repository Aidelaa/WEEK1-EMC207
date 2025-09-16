using UnityEngine;
using UnityEngine.AI;

public class PointAtoB : MonoBehaviour

{
    private NavMeshAgent agent;
    public Transform targetDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetDestination.position);
    }
}
