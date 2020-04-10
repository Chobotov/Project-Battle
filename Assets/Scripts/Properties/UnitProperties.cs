using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperties : MonoBehaviour
{
    [Header("Урон")]
    public float Damage;
    [Header("Скорость передвижения")]
    public float Speed;
    [Header("Пауза между атаками")]
    public float attackDelay;
    [Header("Дистанция для атаки")]
    public float maxDistance;
}
