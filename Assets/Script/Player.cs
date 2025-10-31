using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public float sightRange = 5f;
    private Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= sightRange)
            {
                Renderer enemyRenderer = enemy.GetComponentInChildren<Renderer>();
                if (enemyRenderer != null && playerRenderer != null)
                {
                    // Change enemy color to match player
                    enemyRenderer.material.color = playerRenderer.material.color;
                }

                // Tell the enemy to start following the player
                AIBehaviour ai = enemy.GetComponent<AIBehaviour>();
                if (ai != null)
                {
                    ai.isFollowing = true;
                    ai.player = transform; // give it reference to player
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
