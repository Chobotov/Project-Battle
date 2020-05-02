using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> allUnits = new List<GameObject>();
    public List<GameObject> towerUpdates = new List<GameObject>();
    public Transform spotTowerUpdate;
    public GameObject currentTowerUpdateObject;
    public GameMode gameMode;
    private void Start()
    {
        UpdateDataUnits();
        UpdateTowerUpdates();
    }

    //Обновление у юнита статуса купленного и текущего члена отряда
    public void UpdateDataUnits()
    {
        for (var i = 0; i < SaveLoadManager.Instance.playerData.isPurchasedUnit.Count; i++)
        {
            var index = SaveLoadManager.Instance.playerData.isPurchasedUnit[i];
            allUnits[index].GetComponent<UnitData>().unitProperties.isPurchased = true;
        }

        for (var i = 0; i < allUnits.Count; i++)
        {
            if (i == SaveLoadManager.Instance.playerData.isCurrentUnit[0] ||
                    i == SaveLoadManager.Instance.playerData.isCurrentUnit[1] ||
                    i == SaveLoadManager.Instance.playerData.isCurrentUnit[2])
            {
                allUnits[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = true;
            }
            else
            {
                allUnits[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
            }
        }
    }

    //Обновление у юнита башни статуса купленного и текущего для башни
    public void UpdateTowerUpdates()
    {
        for (var i = 0; i < towerUpdates.Count; i++)
        {
            for (var index = 0; index < SaveLoadManager.Instance.playerData.isPurchasedItem.Count; index++)
            {
                if (i == SaveLoadManager.Instance.playerData.isPurchasedItem[i])
                    towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = true;
                else
                    towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = false;
            }
        }

        for (var i = 0; i < towerUpdates.Count; i++)
        {
            if (i == SaveLoadManager.Instance.playerData.currentTowerUpdate)
            {
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = true;
                if(currentTowerUpdateObject == null)
                    currentTowerUpdateObject = Instantiate(towerUpdates[i], new Vector3(spotTowerUpdate.transform.position.x, spotTowerUpdate.transform.position.y, spotTowerUpdate.transform.position.z),Quaternion.identity);
            }
            else
            {
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
            }
        }
    }
}
