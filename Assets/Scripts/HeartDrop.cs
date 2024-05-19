using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDrop : MonoBehaviour
{

    private Transform player;
    private DataManager data_manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        data_manager = FindObjectOfType<DataManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (data_manager.chosen_cat["Кошкодевочка"] == true)
                playerHealth.Heal(2);
            else
                playerHealth.Heal(1);
            Destroy(gameObject);
        }
    }
}
