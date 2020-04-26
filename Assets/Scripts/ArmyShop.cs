using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyShop : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private List<GameObject> unitItems = new List<GameObject>();
    [SerializeField]
    private List<GameObject> towerItems = new List<GameObject>();

    [Header("Кнопки таб-панели магазина")]
    [SerializeField]
    private GameObject unitsButton,
                       towerButton;
    [Header("Спрайты кнопок таб панели магазина")]
    [SerializeField]
    private Sprite button, selectedButton;

    private void OnMouseDown()
    {
        shop.SetActive(true);
    }

    public void ShopUnits()
    {
        unitsButton.GetComponent<Image>().sprite = selectedButton;
        towerButton.GetComponent<Image>().sprite = button;
        
        for(var i = 0; i < unitItems.Count; i++)
        {
            unitItems[i].SetActive(true);
        }
        for(var i = 0; i < towerItems.Count; i++)
        {
            towerItems[i].SetActive(false);
        }
    }
    public void ShopTower()
    {
        towerButton.GetComponent<Image>().sprite = selectedButton;
        unitsButton.GetComponent<Image>().sprite = button;

        for (var i = 0; i < towerItems.Count; i++)
        {
            towerItems[i].SetActive(true);
        }
        for (var i = 0; i < unitItems.Count; i++)
        {
            unitItems[i].SetActive(false);
        }
    }
}
