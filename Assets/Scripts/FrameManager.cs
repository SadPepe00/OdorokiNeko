using System;
using UnityEngine;

public class FrameManager : MonoBehaviour
{

    [SerializeField] private FrameType[] fr;
    [SerializeField] public GameObject frameGameObject;
    [SerializeField] private Transform parent, pos;

    public CatsGachaManager cgm;
    public GameObject frame;
    public FrameScript fs;
    public string frameName;
    public GameObject GachaSCENE;

    public void ShowFrame()
    {
        frame = Instantiate(frameGameObject, pos.position, Quaternion.identity);
        frame.transform.SetParent(GachaSCENE.transform);
        frame.transform.localScale = new Vector3(1, 1, 1);
        frameName = cgm.rateName;
        fs = frame.GetComponent<FrameScript>();

        if (cgm.rateName == "Legendary")
            fs.fi = DefineFrame(fr[1].frameType);
        else
            fs.fi = DefineFrame(fr[0].frameType);


        return;
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
