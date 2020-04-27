using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarUnitAI : MonoBehaviour
{
    private float nextAttackTime;
    private RaycastHit2D hit;
    private int damage, speed;
    private float attackDelay, maxDistance;
    private UnitData unitData;

    public Transform startRay;

    private EnemyUnit target;
    private UnitData enemyData;

    [SerializeField]
    private GameObject fireball;

    private int layerMaskOnlyPlayerUnits = 1 << 8;
    private int layerMaskWithoutPlayerUnits;


    private void Start()
    {
        layerMaskWithoutPlayerUnits = ~layerMaskOnlyPlayerUnits;
        unitData = GetComponent<UnitData>();
        damage = unitData.unitProperties.Damage;
        speed = unitData.unitProperties.Speed;
        attackDelay = unitData.unitProperties.AttackDelay;
        maxDistance = unitData.unitProperties.Distance;
    }

    private void FixedUpdate()
    {
        if (unitData.unitProperties.state != State.Dead)
            hit = Physics2D.Raycast(startRay.position, startRay.right, Mathf.Infinity , layerMaskWithoutPlayerUnits);
    }

    private void Update()
    {
        if (hit && unitData.unitProperties.state != State.Dead)
        {
            target = hit.collider.gameObject.GetComponent<EnemyUnit>();
            if (hit.distance > maxDistance)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                unitData.unitProperties.state = State.Running;
            }
            if (target != null && hit.distance < maxDistance)
            {
                enemyData = target.GetComponent<UnitData>();
                Attack(target);
            }
            else if (target == null)
            {
                unitData.unitProperties.state = State.Idle;
            }
        }
    }

    private void Attack(EnemyUnit enemy)
    {
        if (nextAttackTime < Time.time && enemyData.dataHealth.Health >= 0)
        {
            GameObject cast = Instantiate(fireball, startRay.transform);
            cast.transform.Rotate(new Vector3(0,0,55));
            cast.GetComponent<Fireball>().currentEnemy = target.gameObject;
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
