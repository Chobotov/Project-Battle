using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] buttons;  
    //Массивы с юнитами
    public GameObject[] _playerUnits;
    public GameObject[] _enemyUnits;
    //Точки спавна
    public GameObject _playerUnit,_enemyUnit;

    private float attackDelay = 10;
    private float nextAttackTime;

    private int _enemyCount = 0;
    private int _playerCount = 0;

    private int id = 0;

    public void GetFirstUnit()
    {
        id = 0;
        if(GameManager.instance.MANA >= 25)
        {
            GameManager.instance.MANA -= 25;
            SpawnPlayerUnit(id);
        }
    }
    public void GetSecondUnit()
    {
        id = 1;
        if (GameManager.instance.MANA >= 50)
        {
            GameManager.instance.MANA -= 50;
            SpawnPlayerUnit(id);
        }
    }
    public void GetThirdtUnit()
    {
        id = 2;
        if (GameManager.instance.MANA >= 100)
        {
            GameManager.instance.MANA -= 100;
            SpawnPlayerUnit(id);
        }
    }
    private void SpawnPlayerUnit(int id)
    {
        Instantiate(_playerUnits[id],_playerUnit.transform);
    }
    public void SpawnEnemyUnit()
    {
        int index = Random.Range(0,3);
        Instantiate(_enemyUnits[index], _enemyUnit.transform);
        _enemyCount++;
    }

    public void Count()
    {
        _enemyCount = 0;
    }

    private void Update()
    {
        if (nextAttackTime < Time.time && _enemyCount < 3 && _enemyUnit != null)
        {
            SpawnEnemyUnit();
            nextAttackTime = Time.time + attackDelay;
        }
    }
}
