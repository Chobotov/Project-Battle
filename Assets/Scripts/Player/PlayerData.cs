using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    [Header("Монеты")]
    public int coins;
    [Header("Энергия")]
    public int energy;
    
    [Header("Текущий отряд игрока")]
    public GameObject[] currentUnits = new GameObject[3];
    [Header("Текущее улучшение для башни")]
    public GameObject currentTowerUpdate;


    public void SetCoinsAndEnergy(int coins, int energy)
    {
        this.coins = coins;
        this.energy = energy;
    }

    public void SetCurrentUnits(GameObject[] currentUnits)
    {
        this.currentUnits = new GameObject[3];
        for(var i = 0; i < currentUnits.Length; i++)
        {
            this.currentUnits[i] = currentUnits[i];
        }
    }

    public void SetCurrentTowerUpdate(GameObject towerUpdate)
    {
        currentTowerUpdate = towerUpdate;
    }
}
