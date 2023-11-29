using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectionListComponent : MonoBehaviour
{

    [SerializeField] private int _catID;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _icon;
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _progressText;

    public int catID
    {
        get { return _catID; }
    }

    public RectTransform rectTransform
    {
        get { return _rectTransform; }
    }

    public void CreateCollection(int id, string title, string description)
    {
        _catID = id;
        _title.text = title;
        _description.text = description;
    }

    public void SetCollection(Sprite icon, int targetValue, int currentValue)
    {
        _icon.sprite = icon;
        _progressText.text = currentValue + "/" + targetValue;
        _progressBar.value = (float)currentValue / (float)targetValue;
    }
}
