using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitProperties : ScriptableObject
{
    [Header("Урон")]
    public int damage;
    [Header("Скорость передвижения")]
    public float speed;
    [Header("Пауза между атаками")]
    public float attackDelay;
    [Header("Дистанция для атаки")]
    public float maxDistance;
}
