using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{

    private DataManager data_Manager;
    public GameObject text_source;

    // Start is called before the first frame update
    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text_source.GetComponent<Text>().text = (data_Manager.level_num - 1).ToString();
    }
}
