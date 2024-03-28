using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    public CatsGachaManager gm;

    public Button button;

    public FrameManager fm;

    public CollectionCheck colCheck;

    private DataManager data_Manager;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
        //gm.testGoldCount = 1000;
        button.onClick.AddListener(OnClick);
        gm.testGoldCount = data_Manager.player_money;
    }

    void OnClick()
    {
        if (gm.testGoldCount > 10)
        {
            Destroy(gm.catGacha);
            Destroy(fm.frame);
            gm.Gacha();
            fm.ShowFrame();

            if (data_Manager.cat_collection[gm.catName])
                Debug.Log($"{gm.catName} is already in your collection!");
            else
            {
                data_Manager.cat_collection[gm.catName] = true;
            }
                

            gm.testGoldCount -= 10;
            data_Manager.player_money -= 10;
        }
        else
        {
            Debug.Log("Out of gold.");
        }
    }
}
