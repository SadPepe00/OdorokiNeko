using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FrameManager : MonoBehaviour
{

    [SerializeField] private FrameType[] fr;
    [SerializeField] public GameObject frameGameObject;
    [SerializeField] private Transform parent, pos;

    public CatsGachaManager cgm;
    public GameObject frame;
    public FrameScript fs;
    public string frameName;

    public void ShowFrame()
    {
        frame = Instantiate(frameGameObject, pos.position, Quaternion.identity);
        frame.transform.SetParent(parent);
        frame.transform.localScale = new Vector3(1, 1, 1);
        frameName = cgm.rateName;
        fs = frame.GetComponent<FrameScript>();

        if (cgm.rateName == "Legendary")
            fs.fi = DefineFrame(fr[1].frameType);
        else
            fs.fi = DefineFrame(fr[0].frameType);


        return;
        /*int rnd = UnityEngine.Random.Range(1, 101);

        for (int i = 0; i < fr.Length; i++)
        {
            if (rnd <= fr[i].rate)
            {
                fs.fi = DefineFrame(fr[i].frameType);
                frameName = fs.fi.name;
                return;
            }
        }*/

    }

    FrameInfo DefineFrame(string rarity)
    {
        FrameType ft = Array.Find(fr, f => f.frameType == rarity);
        FrameInfo[] frameinfo = ft.outFrame;

        if (rarity == "Legendary")
            return frameinfo[0];
        else
            return frameinfo[0];
    }
}
