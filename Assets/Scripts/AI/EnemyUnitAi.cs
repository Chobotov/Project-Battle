﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAI : MonoBehaviour
{
    [SerializeField]
    private float volumeScale = 0.5f;

    private float attackDelay, maxDistance;
    private float nextAttackTime;
    private int damage, speed;
    private RaycastHit2D hit;
    private UnitData unitData;
    public Transform startRay;

    private void Start()
    {
        unitData = GetComponent<UnitData>();
        damage = unitData.unitProperties.Damage;
        speed = unitData.unitProperties.Speed;
        attackDelay = unitData.unitProperties.AttackDelay;
        maxDistance = unitData.unitProperties.Distance;
    }

    private void FixedUpdate()
    {
        if (unitData.unitProperties.state != State.Dead)
            hit = Physics2D.Raycast(startRay.position, -startRay.right);
    }

    private void Update()
    {
        if (hit && unitData.unitProperties.state != State.Dead)
        {
            PlayerUnit playerUnit = hit.collider.gameObject.GetComponent<PlayerUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
                unitData.unitProperties.state = State.Running;
            }
            if (playerUnit != null && hit.distance < maxDistance)
            {
                Attack(playerUnit);
            }
            else if (playerUnit == null)
            {
                unitData.unitProperties.state = State.Idle;
            }
        }
    }

    private void Attack(PlayerUnit playerUnit)
    {
        if (nextAttackTime < Time.time)
        {
            unitData.unitProperties.state = State.Attack;
            playerUnit.TakeDamage(damage);
            nextAttackTime = Time.time + attackDelay;
        }
    }

    //Вызов через анимацию смерти
    private void GetAudio()
    {
        switch (unitData.unitProperties.unitClass)
        {
            case UnitClass.Low:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.Punch, volumeScale);
                break;
            case UnitClass.Middle:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.SwordsFigth, volumeScale);
                break; 
            case UnitClass.Heavy:
                AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.SwordsFigth, volumeScale);
                break;
        }
    }
}
