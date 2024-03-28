using UnityEngine;

public class CollectionCheck : MonoBehaviour
{

    private DataManager data_Manager;

    public void MakeCatVisible()
    {
        foreach (var name in data_Manager.cat_collection.Keys)
        {
            if (data_Manager.cat_collection[name])
            {
                if (!gameObject.transform.Find(name).gameObject.transform.Find("Visible" + name).gameObject.activeInHierarchy)
                {
                    gameObject.transform.Find(name).gameObject.transform.Find("Unknown" + name).gameObject.SetActive(false);
                    gameObject.transform.Find(name).gameObject.transform.Find("Visible" + name).gameObject.SetActive(true);
                }
            }
        }
        
    }
    void Awake()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }

    public void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        { 
            MakeCatVisible();
        }
    }
}
