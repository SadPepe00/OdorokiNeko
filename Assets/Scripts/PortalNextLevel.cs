using UnityEngine;

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
        if (data_Manager.level_num -1 == 10)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (data_Manager.level_num-1 != 10)
            {
                transitionsScript.LoadNextScene("Level" + data_Manager.level_num);
                data_Manager.level_num++;
            }
        }
    }
}
