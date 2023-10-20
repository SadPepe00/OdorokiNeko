using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    public CatsGachaManager gm;

    public Button button;

    void Start()
    {
        
        gm.testGoldCount = 100;
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (gm.testGoldCount > 10)
        {
            Destroy(gm.catGacha);
            gm.Gacha();
            gm.testGoldCount -= 10;
        }
        else
        {
            Debug.Log("Out of gold.");
        }
    }
}
