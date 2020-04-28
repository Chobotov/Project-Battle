using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform squad, tower;
    public List<GameObject> purchasedUnits = new List<GameObject>();
    public List<GameObject> towerUpdates = new List<GameObject>();
    private void OnEnable()
    {
        if (cam.transform.position.x < squad.position.x + 5f && cam.transform.position.x > squad.position.x - 5f)
            ShowUnits();

        else if (cam.transform.position.x < tower.position.x + 5f && cam.transform.position.x > tower.position.x - 5f)
            ShowTowerUpdates();
    }

    private void OnDisable()
    {
        HideUnits();
        HideTowerUpdates();
    }

    private void ShowUnits()
    {
        for (var i = 0; i < purchasedUnits.Count; i++)
        {
            if (GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased)
            {
                purchasedUnits[i].GetComponentInChildren<Text>().text = $"{GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.ManaPrice}";
                purchasedUnits[i].SetActive(true);
            }
        }
    }

    private void ShowTowerUpdates()
    {
        for (var i = 0; i < towerUpdates.Count; i++)
        {
            if (GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased)
            {
                towerUpdates[i].GetComponentInChildren<Text>().text = $"{GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.ManaPrice}";
                towerUpdates[i].SetActive(true);
            }
        }
    }

    private void HideUnits()
    {
        for (var i = 0; i < purchasedUnits.Count; i++)
        {
            if (GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased)
            {
                purchasedUnits[i].GetComponentInChildren<Text>().text = $"{GameManager.Instance.allUnits[i].GetComponent<UnitData>().unitProperties.ManaPrice}";
                purchasedUnits[i].SetActive(false);
            }
        }
    }

    private void HideTowerUpdates()
    {
        for (var i = 0; i < towerUpdates.Count; i++)
        {
            if (GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased)
            {
                towerUpdates[i].GetComponentInChildren<Text>().text = $"{GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.ManaPrice}";
                towerUpdates[i].SetActive(false);
            }
        }
    }
}
