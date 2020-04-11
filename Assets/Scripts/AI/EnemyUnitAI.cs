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

    private void Start()
    {
        damage = GetComponent<UnitData>()._unitProperties.damage;
        speed = GetComponent<UnitData>()._unitProperties.speed;
        attackDelay = GetComponent<UnitData>()._unitProperties.attackDelay;
        maxDistance = GetComponent<UnitData>()._unitProperties.maxDistance;
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(startRay.position, -startRay.right);
    }

    private void Update()
    {
        if (hit)
        {
            if (hit.distance > maxDistance)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }
            if(hit.collider.gameObject.GetComponent<PlayerUnit>() != null && hit.distance < maxDistance)
            {
                //Debug.Log(hit.collider.gameObject.name);
                PlayerUnit unit = hit.collider.gameObject.GetComponent<PlayerUnit>();
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
