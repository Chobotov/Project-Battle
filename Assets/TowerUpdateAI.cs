using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpdateAI : MonoBehaviour
{
    private RaycastHit2D hit;
    private int damage;
    private float maxDistance;
    private UnitData unitData;
    public Transform startRay;
    private EnemyUnit target;
    private UnitData enemyData;
    private List<GameObject> targets = new List<GameObject>();

    IEnumerator Attack(EnemyUnit target)
    {
        while(enemyData.dataHealth.Health >= 0)
        {
            target.TakeDamage(damage);
            yield return null;
        }
    }
    private void Update()
    {
        if (targets.Count > 0)
        {
            target = GetFirstEnemy();
            StartCoroutine(Attack(target));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyUnit>() != null)
        {
            AddEnemyToList(collision.gameObject);
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
}
