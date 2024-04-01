using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
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
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Вызываем метод TakeDamage у скрипта PlayerHealth
                playerHealth.TakeDamage(1);
                // Уничтожаем врага
                DestroyBullet(); // Уничтожаем снаряд
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // Уничтожить снаряд
    }
}
