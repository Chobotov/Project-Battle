using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int speed;
    public int damage;
    private bool isHit;

    [SerializeField]
    private GameObject explosion;

    private Transform enemyTower,
                      playerTower;

    private GameObject[] enemysUnit;

    private Vector2 currentEnemy;

    private float Distance
    {
        get
        {
            return Vector2.Distance(transform.position, currentEnemy);
        }
    }
    private void Start()
    {
        isHit = true;
        FindNearEnemy();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentEnemy, Time.deltaTime*speed);
        if (Distance <= 0.05f && isHit)
        {
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(transform.position, 20f);
            foreach (Collider2D enemy in hitEnemys)
            {
                if (enemy.GetComponent<EnemyUnit>() != null)
                    enemy.GetComponent<EnemyUnit>().TakeDamage(damage);
            }
            isHit = false;
            explosion.SetActive(true);
            Invoke("DestroyMeteor", 0.5f);
        }
    }

    private void FindNearEnemy()
    {
        enemyTower = GameObject.FindGameObjectWithTag("EnemyTower").transform;
        playerTower = GameObject.FindGameObjectWithTag("PlayerTower").transform;

        enemysUnit = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemysUnit.Length == 0)
        {
            currentEnemy = enemyTower.position;
        }
        else
        {
            var distance = float.MaxValue;
            int indexEnemy = 0;
            for (var i = 0; i < enemysUnit.Length; i++)
            {
                var UnitDistance = Mathf.Abs(enemysUnit[i].transform.position.x - playerTower.position.x);
                if (distance > UnitDistance)
                {
                    distance = UnitDistance;
                    indexEnemy = i;
                }
            }
            currentEnemy = new Vector2(enemysUnit[indexEnemy].transform.position.x, enemysUnit[indexEnemy].transform.position.y);
        }
    }

    private void DestroyMeteor()
    {
        Destroy(gameObject);
    }
}
