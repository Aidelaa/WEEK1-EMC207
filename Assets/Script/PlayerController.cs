using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
    }
}
