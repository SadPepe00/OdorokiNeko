using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level_num = 0;
    public int player_health = 5;
    public int player_money = 200;
    public Dictionary<string, bool> cat_collection = new Dictionary<string, bool>(){{"�������", false },{"��������",false}, { "�����", false },{ "��������", false }, { "������", false }, { "��������", false }, { "�������", false }, { "�������", false } };
    public float soud_volume = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
