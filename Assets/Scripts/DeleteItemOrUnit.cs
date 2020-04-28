using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Unit,
    TowerUpdate
}
public class DeleteItemOrUnit : MonoBehaviour
{
    public int id;
    public Type type;
    private void OnMouseDown()
    {
        switch (type)
        {
            case Type.Unit:
                int index = SaveLoadManager.Instance.playerData.isCurrentUnit[id];
                GameManager.Instance.allUnits[index].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
                SaveLoadManager.Instance.playerData.isCurrentUnit[id] = int.MinValue;
                SaveLoadManager.Instance.playerData.currentUnits[id] = null;
                GetComponent<SpriteRenderer>().sprite = null;
                break;
            case Type.TowerUpdate:
                if(SaveLoadManager.Instance.playerData.currentTowerUpdate != -1)
                {
                    index = SaveLoadManager.Instance.playerData.currentTowerUpdate;
                    GameManager.Instance.towerUpdates[index].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
                    SaveLoadManager.Instance.playerData.currentTowerUpdate = -1;
                    GameManager.Instance.UpdateTowerUpdates();
                }
                break;
        }
    }
}
