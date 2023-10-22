using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    public CatsGachaManager gm;

    public Button button;

    public List<string> collectionList;

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

            if (collectionList.Contains(gm.catName))
                Debug.Log($"{gm.catName} is already in your collection!");
            else
                collectionList.Add(gm.catName);

            gm.testGoldCount -= 10;
        }
        else
        {
            Debug.Log("Out of gold.");
        }
    }
}
