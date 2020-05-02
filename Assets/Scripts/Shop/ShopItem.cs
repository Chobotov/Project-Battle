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

    private DataHealth dataHealth; 
    private UnitProperties unitProperties;
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

        dataHealth = unit.GetComponent<UnitData>().dataHealth;
        unitProperties = unit.GetComponent<UnitData>().unitProperties;

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
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        if (SaveLoadManager.Instance.playerData.coins >= price)
        {
            AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.BuyButtonClick, 0.3f);
            SaveLoadManager.Instance.playerData.coins -= price;
            SaveLoadManager.Instance.playerData.isPurchasedUnit.Add(id);
            GameManager.Instance.UpdateDataUnits();
            buyButton.gameObject.SetActive(false);
        }
    }

    public void BuyTowerUpdate()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        if (SaveLoadManager.Instance.playerData.coins >= price)
        {
            AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.BuyButtonClick, 0.3f);
            SaveLoadManager.Instance.playerData.coins -= price;
            SaveLoadManager.Instance.playerData.isPurchasedItem.Add(id);
            GameManager.Instance.UpdateTowerUpdates();
            buyButton.gameObject.SetActive(false);
        }
    }
}
