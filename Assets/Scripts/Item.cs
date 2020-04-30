﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;

    public void SetUnitIntoSquad()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        if (!SaveLoadManager.Instance.IsCurrentSquadHasEmptySlot())
        {
            return;
        }
        else
        {
            int emptySlot = SearchEmptySlot();
            if (emptySlot != int.MinValue)
            {
                SaveLoadManager.Instance.playerData.currentUnits[emptySlot] = GameManager.Instance.allUnits[id];
                SaveLoadManager.Instance.playerData.isCurrentUnit[emptySlot] = id;
                GameManager.Instance.UpdateDataUnits();
            }
        }
    }

    public void SetTowerUpdate()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        if (!SaveLoadManager.Instance.IsCurrentTowerUpdateEmpty())
        {
            return;
        }
        else
        {
            SaveLoadManager.Instance.playerData.currentTowerUpdate = id;
            GameManager.Instance.UpdateTowerUpdates();
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
