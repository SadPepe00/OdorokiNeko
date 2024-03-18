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
        // Вызываем этот метод при получении урона
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Вызываем этот метод при смерти
        // Дополнительные действия при смерти игрока
        // Например, перезапуск уровня, отображение экрана смерти и т.д.
    }
}
