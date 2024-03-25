using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNextLevel : MonoBehaviour
{
    private Transform player;
    private DataManager data_Manager;
    [SerializeField]
    TransitionsScript transitionsScript;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        data_Manager = FindObjectOfType<DataManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (data_Manager.level_num != 6)
            {
                transitionsScript.LoadNextScene("Level" + data_Manager.level_num);
                data_Manager.level_num++;
            }
        }
    }
}
