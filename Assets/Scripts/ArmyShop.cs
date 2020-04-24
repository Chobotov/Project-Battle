using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyShop : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private List<GameObject> Items = new List<GameObject>();
    [SerializeField]
    private Transform shopSpot;

    private void OnMouseDown()
    {
        shop.SetActive(true);
    }
}
