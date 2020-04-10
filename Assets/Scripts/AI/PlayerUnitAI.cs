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

    private void Start()
    {
        damage = GetComponent<UnitProperties>().Damage;
        speed = GetComponent<UnitProperties>().Speed;
        attackDelay = GetComponent<UnitProperties>().attackDelay;
        maxDistance = GetComponent<UnitProperties>().maxDistance;
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(startRay.position, startRay.right);
    }

    private void Update()
    {
        if (hit)
        {
            if (hit.distance > maxDistance)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            if (hit.collider.gameObject.GetComponent<EnemyUnit>() != null && hit.distance < maxDistance)
            {
                //Debug.Log(hit.collider.gameObject.name);
                EnemyUnit unit = hit.collider.gameObject.GetComponent<EnemyUnit>();
                Attack(unit);
            }
        }
    }

    private void Attack(EnemyUnit enemy)
    {
        if(nextAttackTime < Time.time)
        {
            enemy.TakeDamage(damage);
            nextAttackTime = Time.time+attackDelay;
        }        
    }
}
