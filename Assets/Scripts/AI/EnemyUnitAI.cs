using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAI : MonoBehaviour
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
        hit = Physics2D.Raycast(startRay.position, -startRay.right);
    }

    private void Update()
    {
        if (hit)
        {
            PlayerUnit unit = hit.collider.gameObject.GetComponent<PlayerUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }
            if(unit != null && hit.distance < maxDistance)
            {
                Attack(unit);
            }
        }
    }

    private void Attack(PlayerUnit unit)
    {
        if (nextAttackTime < Time.time)
        {
            unit.TakeDamage(damage);
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
