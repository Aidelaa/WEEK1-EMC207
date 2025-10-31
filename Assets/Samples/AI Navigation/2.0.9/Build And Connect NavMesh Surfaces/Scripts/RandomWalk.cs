using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIBehaviour : MonoBehaviour
    {
        [Header("Settings")]
        public float roamRange = 25f;     // how far it can wander
        public float roamDelay = 3f;      // how often it picks new spots

        [HideInInspector] public Transform player;
        [HideInInspector] public bool isFollowing = false;

        private NavMeshAgent agent;
        private Renderer enemyRenderer;
        private float nextRoamTime = 0f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            enemyRenderer = GetComponentInChildren<Renderer>();
        }

        void Update()
        {
            if (!agent.isOnNavMesh) return;

            // 👣 FOLLOW PLAYER
            if (isFollowing && player != null)
            {
                agent.SetDestination(player.position);
                return; // stop random roaming
            }

            // 🚶 RANDOM ROAMING
            if (Time.time >= nextRoamTime && !agent.pathPending && agent.remainingDistance < 0.2f)
            {
                Vector3 randomDirection = Random.insideUnitSphere * roamRange;
                randomDirection.y = 0;

                if (NavMesh.SamplePosition(transform.position + randomDirection, out NavMeshHit hit, roamRange, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                }

                nextRoamTime = Time.time + roamDelay;
            }
        }
    }
}
