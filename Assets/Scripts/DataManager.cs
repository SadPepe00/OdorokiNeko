using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level_num = 0;
    public int player_health = 5;
    public int player_money = 5;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
