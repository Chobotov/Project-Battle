using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Unit : ScriptableObject
{
    public enum Side
    {
        Player,
        Enemy
    }
    public enum Type
    {
        Tower,
        Simpleton,
        Countryman,
        Swordsman,
        Spearman,
        HeavyKnight
    }

    [Header("Sprite")]
    public Sprite sprite;

    [Header("UnitType")]
    public UnitType unitType;

    [Header("Health")]
    public DataHealth dataHealth;

    [Header("Properties")]
    public UnitProperties unitProperties;
   
}
