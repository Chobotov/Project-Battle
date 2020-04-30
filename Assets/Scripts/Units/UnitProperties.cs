﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сторона юнита
public enum Side
{
    Player,
    Enemy
}

//Состояния юнита
public enum State
{
    Idle,
    Running,
    Attack,
    Dead
}

//Класс юнита
public enum UnitClass
{
    Low,
    Middle,
    Heavy,
    Mag
}

[CreateAssetMenu]
public class UnitProperties : ScriptableObject
{
    [Header("Иконка")]
    public Sprite sprite;
    [Header("Сторона юнита")]
    public Side side;
    [Header("Состояние юнита")]
    public State state;
    [Header("Класс юнита")]
    public UnitClass unitClass;
    [Header("Урон")]
    public int Damage;
    [Header("Скорость")]
    public int Speed;
    [Header("Дистанция")]
    public float Distance;
    [Header("Пауза между атаками")]
    public float AttackDelay;
    [Header("Цена за юнита в монетах")]
    public int CoinsPrice;
    [Header("Цена за юнита в мане")]
    public int ManaPrice;
    [Header("Юнит куплен")]
    public bool isPurchased;
    [Header("Юнит состоит в текущем отряде")]
    public bool isCurrentUnit;

    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void SetEnum(Side side,State state, UnitClass unitClass)
    {
        this.side = side;
        this.state = state;
        this.unitClass = unitClass;
    }

    public void SetInt(int damage, int speed, int manaPrice, int coinsPrice)
    {
        Damage = damage;
        Speed = speed;
        ManaPrice = manaPrice;
        CoinsPrice = coinsPrice;
    }

    public void SetFloat(float distance, float attackDelay)
    {
        Distance = distance;
        AttackDelay = attackDelay;
    }

    public void SetBool(bool isPurchased, bool isCurrentUnit)
    {
        this.isPurchased = isPurchased;
        this.isCurrentUnit = isCurrentUnit;
    }
}
