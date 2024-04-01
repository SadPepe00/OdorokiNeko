using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float speed = 5f; // �������� ������ �������
    public float lifespan = 2f; // ����� ����� �������

    private void Start()
    {
        Invoke("DestroyBullet", lifespan); // ���������� ������ ������ lifespan ������
    }

    private void Update()
    {
        Move(); // ������� ������
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // �������� ������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // �������� ����� TakeDamage � ������� PlayerHealth
                playerHealth.TakeDamage(1);
                // ���������� �����
                DestroyBullet(); // ���������� ������
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // ���������� ������
    }
}
