using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionCheck : MonoBehaviour
{

    public List<string> ListOfCatsThatYouHave;

    public void MakeCatVisible()
    {
        foreach (var name in ListOfCatsThatYouHave)
        {
            if (!gameObject.transform.Find(name).gameObject.transform.Find("Visible" + name).gameObject.activeInHierarchy)
            {
                gameObject.transform.Find(name).gameObject.transform.Find("Unknown" + name).gameObject.SetActive(false);
                gameObject.transform.Find(name).gameObject.transform.Find("Visible" + name).gameObject.SetActive(true);
            }
        }
        
    }

    public void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        { 
            MakeCatVisible();
        }
    }
}
