using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Монеты")]
    public int coins;
    [Header("Энергия")]
    public int energy;
    
    [Header("Текущий отряд игрока")]
    public GameObject[] currentUnits = new GameObject[3];
    [Header("Текущее улучшение для башни")]
    public GameObject currentTowerUpdate;
}
