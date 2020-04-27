using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Unit,
    TowerUpdate
}
public class ShopItem : MonoBehaviour
{
    public ItemType itemType;
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
        if(itemType == ItemType.Unit)
        {
            unit = GameManager.Instance.allUnits[id];
        }
        else
        {
            unit = GameManager.Instance.towerUpdates[id];
        }
        
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
        if(SaveLoadManager.Instance.playerData.coins >= price)
        {
            SaveLoadManager.Instance.playerData.coins -= price;
            SaveLoadManager.Instance.playerData.isPurchasedUnit.Add(id);
            GameManager.Instance.UpdateDataUnits();
            buyButton.gameObject.SetActive(false);
        }
    }

    public void BuyItem()
    {
        if (SaveLoadManager.Instance.playerData.coins >= price)
        {
            unit.GetComponent<UnitData>().unitProperties.isPurchased = true;
            SaveLoadManager.Instance.playerData.currentTowerUpdate = true;
            SaveLoadManager.Instance.playerData.coins -= price;
            GameManager.Instance.UpdateTowerUpdates();
            buyButton.gameObject.SetActive(false);
        }
    }
}
