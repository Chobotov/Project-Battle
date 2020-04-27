using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> allUnits = new List<GameObject>();

    public List<GameObject> towerUpdates = new List<GameObject>();

    public void UpdateDataUnits()
    {
        for(var i = 0; i < allUnits.Count; i++)
        {
            if(i < SaveLoadManager.Instance.playerData.isPurchasedUnit.Count && i == SaveLoadManager.Instance.playerData.isPurchasedUnit[i])
                allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased = true;
            else
                allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased = false;
        }

        for (var i = 0; i < allUnits.Count; i++)
        {
            if(i < SaveLoadManager.Instance.playerData.isCurrentUnit.Length && i == SaveLoadManager.Instance.playerData.isCurrentUnit[i])
                allUnits[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = true;
            else
                allUnits[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
        }
    }

    public void UpdateTowerUpdates()
    {
        Debug.Log("True");
        for (var i = 0; i < towerUpdates.Count; i++)
        {
            if (i < SaveLoadManager.Instance.playerData.isPurchasedItem.Count && i == SaveLoadManager.Instance.playerData.isPurchasedItem[i])
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = true;
            else
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = false;
        }

        for (var i = 0; i < towerUpdates.Count; i++)
        {
            if (i < SaveLoadManager.Instance.playerData.isCurrentUnit.Length && i == SaveLoadManager.Instance.playerData.currentTowerUpdate)
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = true;
            else
                towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
        }
    }
}
