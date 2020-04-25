using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;

    public void SetUnitIntoSquad()
    {
        if (!SaveLoadManager.Instance.IsCurrentSquadEmpty())
        {
            return;
        }
        else
        {
            int emptySlot = SearchEmptySlot();
            if (emptySlot != int.MinValue)
            {
                SaveLoadManager.Instance.playerData.currentUnits[emptySlot] = GameManager.Instance.allUnits[id];
            }
        }
    }

    private int SearchEmptySlot()
    {
        int emptySlot = int.MinValue;
        for (var i = 0; i < SaveLoadManager.Instance.playerData.currentUnits.Length; i++)
        {
            if (SaveLoadManager.Instance.playerData.currentUnits[i] == null)
            {
                emptySlot = i;
                break;
            }
        }
        return emptySlot;
    }
}
