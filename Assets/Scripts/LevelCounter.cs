
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{

    private DataManager data_Manager;
    public GameObject text_source;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
        text_source.GetComponent<Text>().text = (data_Manager.level_num - 1).ToString();
    }
}
