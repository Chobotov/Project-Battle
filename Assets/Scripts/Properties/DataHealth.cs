using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class DataHealth : ScriptableObject
{
    [Header ("Здоровье")]
    public int health;
    [Header ("Смерть")]
    public bool isDead;
    [Header("Урон")]
    public int damage;
    [Header("Скорость передвижения")]
    public float speed;
    [Header("Пауза между атаками")]
    public float attackDelay;
    [Header("Дистанция для атаки")]
    public float maxDistance;

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
