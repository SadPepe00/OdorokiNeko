using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCond : MonoBehaviour
{

    private DataManager data_Manager;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
        data_Manager.ChangeMusic("boss");
    }
}
