using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class CollectionSystem : MonoBehaviour
{

    [Header("��������������:")]
    [SerializeField] private CatCollect[] catCollection; // ������������� ������� ������
    [Header("�������:")]
    [SerializeField] private CollectionComponent messageSample; // ������ ��� �����, ������� ������������ ��� ���������
    [SerializeField] private CollectionListComponent listSample; // ������ ��� �����, ������� ������������ � ������
    [Header("���������:")]
#if UNITY_EDITOR
    [SerializeField] private float offset = 10; // �������� ����� ������ � ������
#endif
    [SerializeField] private RectTransform listTransform; // ���������, ������� ����� ��������� ������
    [SerializeField] private CollectionListComponent[] list; // ������������ � ��������� ������ (������������ ������������)

    private static CollectionSystem _internal;
    private static bool _active;
    public delegate void MethodOnCat(int id, string title, string description);
    public event MethodOnCat OnCat;
    private List<Collect> collectLast;

    [System.Serializable]
    struct CatCollect
    {
        public bool isCollected; // ������� ��� ��� ���
        public string title; // ���������, ��������
        public string description; // �������� ����
        public int targetValue; // �� ������� - 0 (�� ������� ����)
        public int currentValue; // ������� - 1
        public Sprite locked; // ������, ����� ��� �� ������
        public Sprite unlocked; // ������, ����� ��� ������
    }

    public static CollectionSystem use
    {
        get { return _internal; }
    }

    public static bool isActive
    {
        get { return _active; }
    }

    void Awake()
    {
        collectLast = new List<Collect>();
        _active = false;
        _internal = this;
        listSample.gameObject.SetActive(false);
        messageSample.gameObject.SetActive(false);
        listTransform.gameObject.SetActive(false);
        Load();
    }

    public void Save()
    {
        string content = string.Empty;

        foreach (var collect in catCollection)
        {
            if (content.Length > 0) content += "|";
            if (collect.isCollected) content += collect.isCollected.ToString(); else content += collect.currentValue.ToString();
        }

        PlayerPrefs.SetString("Cats", content);
        PlayerPrefs.Save();
        Debug.Log(this + " ���������� ��������� �����.");
    }

    void Load()
    {
        if (!PlayerPrefs.HasKey("Cats")) return;

        string[] content = PlayerPrefs.GetString("Cats").Split(new char[] { '|' });

        if (content.Length == 0 || content.Length != catCollection.Length) return;

        for (int i = 0; i < catCollection.Length; i++)
        {
            int j = Parse(content[i]);

            if (j < 0)
            {
                catCollection[i].currentValue = catCollection[i].targetValue;
                catCollection[i].isCollected = true;
            }
            else
            {
                catCollection[i].currentValue = j;
            }
        }
    }

    int Parse(string text)
    {
        int value;
        if (int.TryParse(text, out value)) return value;
        return -1;
    }

    public void ShowAchievementList(bool value)
    {
        if (value) // ���������� ������, ����� �������
        {
            for (int i = 0; i < catCollection.Length; i++)
            {
                Sprite sprite = (catCollection[i].isCollected) ? catCollection[i].unlocked : catCollection[i].locked;
                list[i].SetCollection(sprite, catCollection[i].targetValue, catCollection[i].currentValue);
            }
        }

        _active = value;
        listTransform.gameObject.SetActive(value);
    }

    // id - ������ ���� �� ������
    // value - �� ������� ������� ��������
    public void AdjustCollection(int id, int value)
    {
        if (catCollection[id].isCollected || id < 0 || id > catCollection.Length) return;

        catCollection[id].currentValue += value;

        if (catCollection[id].currentValue < 0) catCollection[id].currentValue = 0;

        if (catCollection[id].currentValue >= catCollection[id].targetValue)
        {
            catCollection[id].currentValue = catCollection[id].targetValue;
            catCollection[id].isCollected = true;
            OnCat(id, catCollection[id].title, catCollection[id].description);

            if (!messageSample.isActive) // ���������� ����, ���� � ������ ������ �� ������������
            {
                messageSample.SetCat(catCollection[id].unlocked, catCollection[id].title, catCollection[id].description);
            }
            else // ��� ���������� ����, ����� �������� �����
            {
                Collect a = new Collect();
                a.description = catCollection[id].description;
                a.title = catCollection[id].title;
                a.sprite = catCollection[id].unlocked;
                collectLast.Add(a);
            }
        }
    }

    struct Collect
    {
        public string title;
        public string description;
        public Sprite sprite;
    }

    public void ShowNextCat() // ����������� ����� �����, ���� ���� ������� ����� ���������
    {
        int j = -1;
        for (int i = 0; i < collectLast.Count; i++)
        {
            j = i;
        }

        if (j < 0)
        {
            messageSample.isActive = false;
            return;
        }

        messageSample.SetCat(collectLast[j].sprite, collectLast[j].title, collectLast[j].description);
        collectLast.RemoveAt(j);
    }

#if UNITY_EDITOR
    public void CreateInEditor() // ���������� ��� �������� ������
    {
        foreach (CollectionListComponent e in list)
        {
            if (e) DestroyImmediate(e.gameObject);
        }
        float step = listSample.rectTransform.sizeDelta.y + offset;
        float sizeY = step * catCollection.Length;
        listTransform.sizeDelta = new Vector2(listSample.rectTransform.sizeDelta.x, sizeY);
        float posY = step * catCollection.Length / 2 + step / 2;
        list = new CollectionListComponent[catCollection.Length];
        for (int i = 0; i < catCollection.Length; i++)
        {
            posY -= step;
            RectTransform tr = Instantiate(listSample.rectTransform) as RectTransform;
            tr.SetParent(listTransform);
            tr.localScale = Vector3.one;
            tr.anchoredPosition = new Vector2(0, posY);
            tr.gameObject.SetActive(true);
            tr.name = "Achievement_" + i;
            list[i] = tr.GetComponent<CollectionListComponent>();
            list[i].CreateCollection(i, catCollection[i].title, catCollection[i].description);
        }
    }
#endif
}