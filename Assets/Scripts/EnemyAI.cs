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
    private DataManager data_Manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        data_Manager = FindObjectOfType<DataManager>();
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
            // ��������� ������������ � ����� ��� �������
            Destroy(gameObject);
            data_Manager.player_money += 10;
        }
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // �������� ����� TakeDamage � ������� PlayerHealth
                playerHealth.TakeDamage(damage);
                // ���������� �����
                Destroy(gameObject);
            }
        }
    }
}
