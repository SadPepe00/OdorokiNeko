using UnityEngine;

public class BossShort : MonoBehaviour
{
    public float speed = 5f; // Скорость полета снаряда
    public float lifespan = 2f; // Время жизни снаряда

    private void Start()
    {
        Invoke("DestroyBullet", lifespan); // Уничтожить снаряд спустя lifespan секунд
    }

    private void Update()
    {
        Move(); // Двигаем снаряд
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Движение вперед
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Логика обработки столкновения с игроком
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Вызываем метод TakeDamage у скрипта PlayerHealth
                playerHealth.TakeDamage(1);
                // Уничтожаем врага
                DestroyBullet();
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // Уничтожить снаряд
    }
}