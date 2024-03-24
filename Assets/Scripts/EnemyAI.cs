using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float slowMoveSpeed = 2f;
    public float chaseMoveSpeed = 4f;
    public float slowChaseRange = 5f;
    public float fastChaseRange = 2f;
    public float damage = 10f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= fastChaseRange)
            {
                MoveTowardsPlayer(chaseMoveSpeed);
            }
            else if (distanceToPlayer <= slowChaseRange)
            {
                MoveTowardsPlayer(slowMoveSpeed);
            }
        }
    }

    void MoveTowardsPlayer(float speed)
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Обработка столкновения с пулей или игроком
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Вызываем метод TakeDamage у скрипта PlayerHealth
                playerHealth.TakeDamage(damage);
                // Уничтожаем врага
                Destroy(gameObject);
            }
        }
    }
}
