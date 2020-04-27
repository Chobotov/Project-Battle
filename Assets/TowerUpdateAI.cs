using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpdateAI : MonoBehaviour
{
    public int damage;
    public Transform startRay;
    public float attackDelay;
    public float speed;
    
    private float nextAttackTime;
    private RaycastHit2D hit;
    private float maxDistance;
    private UnitData unitData;
    private EnemyUnit target;
    private UnitData enemyData;
    
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();
    private Vector2 endRay;
    [SerializeField]
    private GameObject fireball;

    private void Start()
    {
        endRay = new Vector2(40f, -25f);
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(startRay.position, endRay);

        if (hit && hit.collider.gameObject.GetComponent<EnemyUnit>() != null)
        {
            if (!targets.Contains(hit.collider.gameObject))
            {
                AddEnemyToList(hit.collider.gameObject);
            }
        }
    }

    private void Update()
    {
        if (targets.Count > 0)
        {
            target = GetFirstEnemy();
            Attack(target);
        }
    }

    private void AddEnemyToList(GameObject enemy)
    {
        targets.Add(enemy);
    }

    private void RemoveEnemyFromList(GameObject currentTarget)
    {
        targets.Remove(currentTarget);
    }

    private EnemyUnit GetFirstEnemy()
    {
        enemyData = targets[0].GetComponent<UnitData>();
        return targets[0].GetComponent<EnemyUnit>();
    }
    private void Attack(EnemyUnit target)
    {
        if (nextAttackTime < Time.time && enemyData.dataHealth.Health >= 0)
        {
            GameObject cast =  Instantiate(fireball,startRay.transform);
            cast.GetComponent<Fireball>().currentEnemy = target.gameObject;
            nextAttackTime = Time.time + attackDelay;
        }
        else if (enemyData.dataHealth.Health < 0)
            RemoveEnemyFromList(targets[0]);
    }
}
