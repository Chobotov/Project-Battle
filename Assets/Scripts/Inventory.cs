using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform spot;
    public GameObject Item;
    public List<GameObject> items;
    private void OnEnable()
    {
        items = new List<GameObject>();
        for (var i = 0; i < GameManager.Instance.unitDataBase.buyUnits.Count; i++)
        {       
            Item.GetComponent<Item>().img.sprite = GameManager.Instance.unitDataBase.buyUnits[i].GetComponent<UnitData>().unitProperties.sprite;
            Item.GetComponent<Item>().id = i;
            items.Add(Item);
            Debug.Log(i);
            Instantiate(Item, spot);
        }
    }

    private void OnDisable()
    {
        for (var i = 0; i < items.Count; i++)
        {
            DestroyImmediate(items[i],true);
        }
    }
}
