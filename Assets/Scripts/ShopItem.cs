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
                 speedText;
    [Header("Изображение юнита")]
    public Image image;

    private Button buy;

    public int id;

    public int Price;
    public GameObject Unit;

    private void OnEnable()
    {
        //Unit = GameManager.Instance.UnitDataBase.allUnits[id];

        var dataHealth = Unit.GetComponent<UnitData>().dataHealth; 
        var unitProperties = Unit.GetComponent<UnitData>().unitProperties;

        image.sprite = Unit.GetComponent<SpriteRenderer>().sprite;

        Price = unitProperties.CoinsPrice;

        titleText.text = Unit.name;
        healthText.text = $"{dataHealth.Health}";
        damageText.text = $"{unitProperties.Damage}";
        manaPriceText.text = $"{unitProperties.ManaPrice}";
        speedText.text = $"{unitProperties.Speed}";
    }

    public void BuyUnit()
    {
        SaveLoadManager.Instance.playerData.coins -= Price;
        //GameManager.Instance.UnitDataBase.purchasedUnits.Add(GameManager.Instance.UnitDataBase.allUnits[id]);
        buy.gameObject.SetActive(false);
    }


}
