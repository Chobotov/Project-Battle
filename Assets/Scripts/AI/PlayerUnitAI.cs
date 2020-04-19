using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAI : MonoBehaviour
{
    private float nextAttackTime;
    private RaycastHit2D hit;
    private int damage, speed;
    private float attackDelay, maxDistance;
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
        hit = Physics2D.Raycast(startRay.position,startRay.right);
    }

    private void Update()
    {
        if (hit)
        {
            EnemyUnit enemy = hit.collider.gameObject.GetComponent<EnemyUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                unitData.unitProperties.state = State.Running;
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
            unitData.unitProperties.state = State.Attack;
            enemy.TakeDamage(damage);
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
