using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public int id;
    private void OnMouseDown()
    {
        GameManager.Instance.allUnits[SaveLoadManager.Instance.playerData.isCurrentUnit[id]].GetComponent<UnitData>().unitProperties.isCurrentUnit = false; ;
        SaveLoadManager.Instance.playerData.isCurrentUnit[id] = int.MinValue;
        SaveLoadManager.Instance.playerData.currentUnits[id] = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
