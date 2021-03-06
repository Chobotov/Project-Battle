﻿using System;
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
    public int currentTowerUpdate = -1;

    public int [] isCurrentUnit = new int[3];
    public List<int> isPurchasedUnit = new List<int>();
    public List<int> isPurchasedItem = new List<int>();

    public bool isFirstLaunch = true;


    public void SetCoinsAndEnergy(int coins, int energy)
    {
        if (coins < 0)
            this.coins = 0;
        else
            this.coins = coins;
        if (energy > 10)
            this.energy = 10;
        else
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

    public void SetCurrentTowerUpdate(int towerUpdate)
    {
        currentTowerUpdate = towerUpdate;
    }
}
