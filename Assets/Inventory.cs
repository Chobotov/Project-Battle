using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> purchasedUnits = new List<GameObject>();
    private void OnEnable()
    {
        for(var i = 0; i < purchasedUnits.Count; i++)
        {
            if (GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased)
            {
                purchasedUnits[i].GetComponentInChildren<Text>().text = $"{GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.ManaPrice}";
                purchasedUnits[i].SetActive(true);
            }
        }
    }
}
