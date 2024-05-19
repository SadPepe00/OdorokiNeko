using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCat : MonoBehaviour
{
    [SerializeField]
    public bool Equipflag;
    public string cat_name;
    private DataManager data_Manager;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    public void ClickedCat()
    {
        if (!Equipflag)
        {
            
            data_Manager.EquipCat(cat_name);
        }
        else
        {
            data_Manager.UnequipCat(cat_name);
        }
        }
    }
