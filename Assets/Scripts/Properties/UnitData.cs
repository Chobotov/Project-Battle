using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    public UnitType.Side side;
    public UnitType.Type type;
    public Unit unit;

    private void Start()
    {
        var health = unit.dataHealth.health;
        unit.dataHealth = ScriptableObject.CreateInstance(typeof(DataHealth)) as DataHealth;
        unit.dataHealth.SetHealth(health);
    }
}
