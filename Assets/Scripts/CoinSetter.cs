using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSetter : MonoBehaviour
{
    private DataManager data_Manager;
    public GameObject text_source;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }
    private void Update()
    {
        text_source.GetComponent<Text>().text = data_Manager.player_money.ToString();
    }
}
