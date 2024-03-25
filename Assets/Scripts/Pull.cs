using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    public CatsGachaManager gm;

    public Button button;

    public List<string> collectionList;

    public FrameManager fm;

    void Start()
    {
        gm.testGoldCount = 1000;
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (gm.testGoldCount > 10)
        {
            Destroy(gm.catGacha);
            Destroy(fm.frame);
            gm.Gacha();
            fm.ShowFrame();

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
