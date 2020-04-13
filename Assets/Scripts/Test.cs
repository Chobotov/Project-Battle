using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] buttons;  
    //Точки спавна
    public GameObject playerUnit,enemyUnit;

    private float attackDelay = 10;
    private float nextAttackTime;

    private int enemyCount = 0;
    private int playerCount = 0;

    private int id = 0;

    public void GetFirstUnit()
    {
        id = 0;
        if(GameManager.Instance.mana.MANA >= 25)
        {
            GameManager.Instance.mana.MANA -= 25;
            SpawnPlayerUnit(id);
        }
    }
    public void GetSecondUnit()
    {
        id = 1;
        if (GameManager.Instance.mana.MANA >= 50)
        {
            GameManager.Instance.mana.MANA -= 50;
            SpawnPlayerUnit(id);
        }
    }
    public void GetThirdtUnit()
    {
        id = 2;
        if (GameManager.Instance.mana.MANA >= 100)
        {
            GameManager.Instance.mana.MANA -= 100;
            SpawnPlayerUnit(id);
        }
    }
    private void SpawnPlayerUnit(int id)
    {
        Instantiate(GameManager.Instance._playerUnits[id],playerUnit.transform);
    }
    public void SpawnEnemyUnit()
    {
        int index = Random.Range(0,3);
        Instantiate(GameManager.Instance._enemyUnits[index], enemyUnit.transform);
        enemyCount++;
    }
    private void Update()
    {
        if (nextAttackTime < Time.time && enemyCount < 3 && enemyUnit != null)
        {
            SpawnEnemyUnit();
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
