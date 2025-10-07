using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();
        private Animator animation;
        public NavMeshAgent agent;


        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            animation = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animation.SetBool("Running",false);
            }
            else
            {
                animation.SetBool("Running",true);
            }
        }

        void OnAnimatorMove()
        {
            if(animation.GetBool("Running"))
            {
                m_Agent.speed = (animation.deltaPosition/Time.deltaTime).magnitude;
            }
        }
    }
}