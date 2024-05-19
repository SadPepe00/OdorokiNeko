using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private DataManager data_Manager;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    public void Click()
    {
        data_Manager.UnlockCats();
    }
    
}
