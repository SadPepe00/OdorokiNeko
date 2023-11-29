using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        // �������� ���� ����� ��� ��������� �����
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // �������� ���� ����� ��� ������
        // �������������� �������� ��� ������ ������
        // ��������, ���������� ������, ����������� ������ ������ � �.�.
    }
}
