using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCatDescription : MonoBehaviour
{
    [SerializeField] GameObject CatDescription;
    void Start()
    {
        CatDescription.SetActive(false);
    }

    public void OnMouseOver()
    {
        CatDescription.SetActive(true);
    }

    public void OnMouseExit()
    {
        CatDescription.SetActive(false);
    }
}
