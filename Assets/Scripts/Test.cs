using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] buttons;  
    public GameObject[] _playerUnits;
    public GameObject[] _enemyUnits;
    public GameObject _playerUnit,_enemyUnit;

    private float attackDelay = 10;
    private float nextAttackTime;

    private int count = 0;

    private int id = 0;

    public void GetFirstUnit()
    {
        id = 0;
        SpawnPlayerUnit(id);
    }
    public void GetSecondUnit()
    {
        id = 1;
        SpawnPlayerUnit(id);
    }
    public void GetThirdtUnit()
    {
        id = 2;
        SpawnPlayerUnit(id);
    }
    private void SpawnPlayerUnit(int id)
    {
        Instantiate(_playerUnits[id],_playerUnit.transform);
    }
    public void SpawnEnemyUnit()
    {
        int index = Random.Range(0,4);
        Instantiate(_enemyUnits[index], _enemyUnit.transform);
        count++;
    }

    public void Count()
    {
        count = 0;
    }

    private void Update()
    {

        if (nextAttackTime < Time.time && count < 5)
        {
            SpawnEnemyUnit();
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
