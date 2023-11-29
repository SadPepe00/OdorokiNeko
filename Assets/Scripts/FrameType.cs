using UnityEngine;

[System.Serializable]
public class FrameType
{
    public string frameType;

    [Range(0, 1)]

    public int rate;

    public FrameInfo[] outFrame;
}