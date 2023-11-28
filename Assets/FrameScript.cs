using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameScript : MonoBehaviour
{
    public FrameInfo fi;
    [SerializeField] private Image img;

    void Start()
    {
        if (fi != null)
        {
            img.sprite = fi.image;
        }
    }

    private void Update()
    {

    }
}
