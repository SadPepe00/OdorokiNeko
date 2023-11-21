using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 5f;
    public float attackRange = 2f;

    public float moveSpeed = 3f;
    public float attackSpeed = 6f;

    private bool isChasing = false;

    [SerializeField]
    private GameObject enemyGm;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            isChasing = false;
        }

        if (isChasing && distanceToPlayer < attackRange)
        {
            AttackPlayer();
        }
        if (distanceToPlayer < 0.5)
        {
            Destroy(enemyGm);
            Debug.Log("Boom!");
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * attackSpeed * Time.deltaTime);

        
       
    }

}
