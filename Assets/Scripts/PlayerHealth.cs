using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private int currentHealth;
    private DataManager data_Manager;

    private void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
        currentHealth = data_Manager.player_health;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        data_Manager.player_health-=amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        data_Manager.player_health += amount;
    }

    private void Die()
    {
        data_Manager.level_num = 2;
        data_Manager.player_health = 10;
        data_Manager.ChangeMusic("intro");
        SceneManager.LoadScene("DeathScreen");
    }
}
