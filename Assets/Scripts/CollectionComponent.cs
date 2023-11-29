using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectionComponent : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;

    public bool isActive { get; set; }

    void Show()
    {
        gameObject.SetActive(true);

        StartCoroutine(Wait(5));
    }

    void Hide()
    {
        gameObject.SetActive(false);

        CollectionSystem.use.ShowNextCat();
    }

    public void SetCat(Sprite icon, string title, string description)
    {
        _icon.sprite = icon;
        _title.text = title;
        _description.text = description;
        isActive = true;
        Show();
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        Hide();
    }
}
