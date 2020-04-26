using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Хар-ки юнита")]
    public Text titleText,
                 healthText,
                 damageText,
                 manaPriceText,
                 speedText,
                 coinsPrice;
    [Header("Изображение юнита")]
    public Image image;

    public Button buyButton;

    public int id;
    public int price;
    public GameObject unit;

    private void OnEnable()
    {
        unit = GameManager.Instance.allUnits[id];

        if (unit.GetComponent<UnitData>().unitProperties.isPurchased == true)
            buyButton.gameObject.SetActive(false);

        var dataHealth = unit.GetComponent<UnitData>().dataHealth; 
        var unitProperties = unit.GetComponent<UnitData>().unitProperties;

        image.sprite = unit.GetComponent<SpriteRenderer>().sprite;
        image.SetNativeSize();

        price = unitProperties.CoinsPrice;
        coinsPrice.text = $"{price}";

        titleText.text = unit.name;
        healthText.text = $"{dataHealth.Health}";
        damageText.text = $"{unitProperties.Damage}";
        manaPriceText.text = $"{unitProperties.ManaPrice}";
        speedText.text = $"{unitProperties.Speed}";
    }

    public void BuyUnit()
    {
        SaveLoadManager.Instance.playerData.coins -= price;
        GameManager.Instance.allUnits[id].GetComponent<UnitData>().unitProperties.isPurchased = true;
        buyButton.gameObject.SetActive(false);
    }
}
