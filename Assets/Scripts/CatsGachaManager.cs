using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CatsGachaManager : MonoBehaviour
{
    [SerializeField] private CatsGachaRate[] gacha;
    [SerializeField] private Transform parent, pos;
    [SerializeField] private GameObject catGachaGameObject;

    GameObject catGacha;
    CatsGacha cat;

    public void Gacha()
    {
        if (catGacha == null)
        {
            catGacha = Instantiate(catGachaGameObject, pos.position, Quaternion.identity) as GameObject;
            catGacha.transform.SetParent(parent);
            catGacha.transform.localScale = new Vector3(1, 1, 1);
            cat = catGacha.GetComponent<CatsGacha>();

            int rnd = UnityEngine.Random.Range(1, 101);

            for (int i = 0; i < gacha.Length; i++)
            {
                if (rnd <= gacha[i].rate)
                {
                    cat.cgi = Reward(gacha[i].rarity);
                    return;
                }
            }
        }
    }

    public int Rates(string rarity)
    {
        CatsGachaRate cgr = Array.Find(gacha, rt => rt.rarity == rarity);
        if (cgr != null)
        {
            return cgr.rate;
        }
        else
        {
            return 0;
        }
    }

    catsGachaInfo Reward(string rarity)
    {
        CatsGachaRate cgr = Array.Find(gacha, rt => rt.rarity == rarity);
        catsGachaInfo[] reward = cgr.reward;

        int rnd = UnityEngine.Random.Range(0, reward.Length);
        
        return reward[rnd];
    }
}

[CustomEditor(typeof(CatsGachaManager))]
public class CatsGachaEditor : Editor
{
    public int Common, Rare, Legendary;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        CatsGachaManager cgm = (CatsGachaManager)target;

        Common = EditorGUILayout.IntField("Common", (cgm.Rates("Common") - cgm.Rates("Rare")));
        Rare = EditorGUILayout.IntField("Rare", (cgm.Rates("Rare") - cgm.Rates("Legendary")));
        Legendary = EditorGUILayout.IntField("Legendary", (cgm.Rates("Legendary")));
    }
}
