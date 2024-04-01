
using UnityEngine;
using UnityEngine.UI;

public class HeartsCounter : MonoBehaviour
{

    private DataManager data_Manager;
    public GameObject text_source;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    void Update()
    {
        text_source.GetComponent<Text>().text = (data_Manager.player_health).ToString();
    }
}
