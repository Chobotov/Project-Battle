using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Text playerCoins;
    [SerializeField]
    private GameObject scrollRect;
    [Header("Кнопки таб-панели магазина")]
    [SerializeField]
    private GameObject unitsButton,
                       towerButton;
    [Header("Спрайты кнопок таб панели магазина")]
    [SerializeField]
    private Sprite button, selectedButton;
    [SerializeField]
    private List<GameObject> unitItems = new List<GameObject>();
    [SerializeField]
    private List<GameObject> towerItems = new List<GameObject>();

    private void Start()
    {
        ShopUnits();
    }
    private void LateUpdate()
    {
        playerCoins.text = $"{SaveLoadManager.Instance.playerData.coins}";
    }

    public void ShopUnits()
    {
        scrollRect.GetComponent<ScrollRect>().content.localPosition = new Vector3(0, -300, 0);
        unitsButton.GetComponent<Image>().sprite = selectedButton;
        towerButton.GetComponent<Image>().sprite = button;

        for (var i = 0; i < unitItems.Count; i++)
        {
            unitItems[i].SetActive(true);
        }
        for (var i = 0; i < towerItems.Count; i++)
        {
            towerItems[i].SetActive(false);
        }
    }
    public void ShopTower()
    {
        scrollRect.GetComponent<ScrollRect>().content.localPosition = new Vector3(0, -300, 0);
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
