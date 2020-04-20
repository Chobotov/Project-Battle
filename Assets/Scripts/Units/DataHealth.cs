using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataHealth : ScriptableObject
{
    [Header("Жизнь")]
    [Range(0, 100)]
    public int Health = 100;
    [Header("Юнит атакует")]
    public bool isAttack = false;
    [Header("Юнит бежит")]
    public bool isRunning = false;
    [Header("Юнит мертв")]
    public bool isDead = false;


    public void SetHealth(int health)
    {
        Health = health;
    }

    public void SetBool(bool isAttack, bool isRunning, bool isDead)
    {
        this.isAttack = isAttack;
        this.isRunning = isRunning;
        this.isDead = isDead;
    }
}
