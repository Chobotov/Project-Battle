using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int speed;
    public int damage;

    [SerializeField]
    private GameObject explosion;

    private Transform enemyTower,
                      playerTower;

    private GameObject[] enemysUnit;

    private Transform currentEnemy;

    private float Distance
    {
        get
        {
            return Mathf.Abs(currentEnemy.position.y - transform.position.y);
        }
    }
    private void Start()
    {
        enemyTower = GameObject.FindGameObjectWithTag("EnemyTower").transform;
        playerTower = GameObject.FindGameObjectWithTag("PlayerTower").transform;

        enemysUnit = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemysUnit.Length == 0)
        {
            currentEnemy = enemyTower;
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
            currentEnemy = enemysUnit[indexEnemy].transform;
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentEnemy.position, Time.deltaTime*speed);
        if(Distance <= 0.1f)
        {
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(transform.position,2f);
            foreach(Collider2D enemy in hitEnemys)
            {
                Debug.Log(enemy.name);
                if(enemy.GetComponent<EnemyUnit>() != null)
                    enemy.GetComponent<EnemyUnit>().TakeDamage(damage);
            }
            explosion.SetActive(true);
            Invoke("DestroyMeteor", 0.5f);
        }
    }

    private void DestroyMeteor()
    {
        Destroy(gameObject);
    }
}
