
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level_num = 0;
    public int player_health = 5;
    public int player_money = 200;
    public Dictionary<string, bool> cat_collection = new Dictionary<string, bool>(){{"Буханка", false },{"Синнабон",false}, { "Рыжик", false },{ "Печенька", false }, { "Снежок", false }, { "Фантомка", false }, { "Люцикот", false }, { "НекоАрк", false } };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
