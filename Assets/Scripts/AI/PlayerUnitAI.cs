using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAI : MonoBehaviour
{
    private float maxDistance;
    private float damage;
    private float speed;
    private float attackDelay;
    private float nextAttackTime;
    private RaycastHit2D hit;

    public Transform startRay;
    UnitLinks links;

    private void Start()
    {
        links = GetComponent<UnitLinks>();
        damage = links.unitData.unitProperties.damage;
        speed = links.unitData.unitProperties.speed;
        attackDelay = links.unitData.unitProperties.attackDelay;
        maxDistance = links.unitData.unitProperties.maxDistance;
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(startRay.position, startRay.right);
    }

    private void Update()
    {
        if (hit)
        {
            EnemyUnit enemy = hit.collider.gameObject.GetComponent<EnemyUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            if (enemy != null && hit.distance < maxDistance)
            {
                Attack(enemy);
            }
        }
    }
    private void Attack(EnemyUnit enemy)
    {
        if (nextAttackTime < Time.time)
        {
            enemy.TakeDamage(damage);
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
