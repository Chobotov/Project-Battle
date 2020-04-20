using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    public DataHealth dataHealth;
    public UnitProperties unitProperties;

    private void Start()
    {
        SetDataHealth();
        SetDataProperties();
    }


    private void SetDataHealth()
    {
        var health = dataHealth.Health;
        dataHealth = ScriptableObject.CreateInstance(typeof(DataHealth)) as DataHealth;
        dataHealth.SetHealth(health);
        dataHealth.SetBool(false, false, false);
    }

    private void SetDataProperties()
    {
        Sprite sprite = unitProperties.sprite;
        Side side = unitProperties.side;
        State state = unitProperties.state;
        int Damage = unitProperties.Damage;
        int Speed = unitProperties.Speed;
        float Distance = unitProperties.Distance;
        float AttackDelay = unitProperties.AttackDelay;
        bool isPurchased = unitProperties.isPurchased;
        bool isCurrentUnit = unitProperties.isCurrentUnit;
        unitProperties = ScriptableObject.CreateInstance(typeof(UnitProperties)) as UnitProperties;
        unitProperties.SetSprite(sprite);
        unitProperties.SetEnum(side, state);
        unitProperties.SetInt(Damage, Speed);
        unitProperties.SetFloat(Distance, AttackDelay);
        unitProperties.SetBool(isPurchased, isCurrentUnit);
    }
}
