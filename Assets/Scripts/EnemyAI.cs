using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float slowMoveSpeed = 2f;
    public float chaseMoveSpeed = 4f;
    public float slowChaseRange = 5f;
    public float fastChaseRange = 2f;
    public int damage = 1;
    public GameObject drop;

    private Transform player;
    private Rigidbody2D rb;
    private DataManager data_Manager;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        data_Manager = FindObjectOfType<DataManager>();

        if (data_Manager.chosen_cat["Люцикот"] == true)
        {
            damage++;
        }

        if (data_Manager.level_num - 1 == 10)
        {
            Destroy(gameObject);
        }
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
            if (UnityEngine.Random.Range(0, 100) < 30)
            {
                Instantiate(drop, new Vector3Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y,-1),gameObject.transform.rotation);
            }
            data_Manager.player_money += 5;
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
