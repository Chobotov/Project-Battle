using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitType : ScriptableObject
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
}
