using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    public DataHealth dataHealth;
    public UnitProperties unitProperties;

    private void Start()
    {
        var health = dataHealth.Health;
        dataHealth = ScriptableObject.CreateInstance(typeof(DataHealth)) as DataHealth;
        dataHealth.SetHealth(health);
        unitProperties.state = State.Idle;
    }
}
