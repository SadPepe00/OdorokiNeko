using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCat : MonoBehaviour
{
    [SerializeField]
    public bool Equipflag;
    public string cat_name;
    private DataManager data_Manager;
    [SerializeField]
    private GameObject check_mark_image;


    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();

    }

    public void ClickedCat()
    {
        if (!Equipflag)
        { 
            data_Manager.EquipCat(cat_name);
            check_mark_image.SetActive(true);
        }
        else
        {
            data_Manager.UnequipCat(cat_name);
            check_mark_image.SetActive(false);
        }
    }
}
