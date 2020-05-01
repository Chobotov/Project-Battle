using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyShop : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;

    private void OnMouseDown()
    {
        shop.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
