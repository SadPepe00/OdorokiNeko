using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCatDescription : MonoBehaviour
{
    [SerializeField] GameObject cat_description;
    void Start()
    {
        cat_description.SetActive(false);
    }

    public void OnMouseOver()
    {
        cat_description.SetActive(true);
    }

    public void OnMouseExit()
    {
        cat_description.SetActive(false);
    }
    
}
