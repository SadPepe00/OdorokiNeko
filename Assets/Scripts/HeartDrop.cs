using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDrop : MonoBehaviour
{

    private Transform player;
    private DataManager data_Manager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        data_Manager = FindObjectOfType<DataManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Heal(1);
            Destroy(gameObject);
        }
    }
}
