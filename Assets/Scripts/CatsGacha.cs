using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatsGacha : MonoBehaviour
{
    public catsGachaInfo cgi;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI name;

    void Start()
    {
        if (cgi != null)
        {
            img.sprite = cgi.image;
            name.text = cgi.name;
        }
    }
}
