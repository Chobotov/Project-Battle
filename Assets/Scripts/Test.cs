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

    private int id = 0;

    public void GetFirstUnit()
    {
        id = 0;
        if(GamePlay.Instance.mana.MANA >= 25 && GamePlay.Instance.playerCount < 3)
        {
            GamePlay.Instance.mana.MANA -= 25;
            SpawnPlayerUnit(id);
        }
    }
    public void GetSecondUnit()
    {
        id = 1;
        if (GamePlay.Instance.mana.MANA >= 50 && GamePlay.Instance.playerCount < 3)
        {
            GamePlay.Instance.mana.MANA -= 50;
            SpawnPlayerUnit(id);
        }
    }
    public void GetThirdtUnit()
    {
        id = 2;
        if (GamePlay.Instance.mana.MANA >= 100 && GamePlay.Instance.playerCount < 3)
        {
            GamePlay.Instance.mana.MANA -= 100;
            SpawnPlayerUnit(id);
        }
    }
    private void SpawnPlayerUnit(int id)
    {
        if (GamePlay.Instance.playerCount < 3)
        {
            Instantiate(GameManager.Instance.playerData.squad.currentPlayerUnits[id], playerUnit.transform);
            GamePlay.Instance.playerCount++;
            Debug.Log("spawn");
        }
    }
    public void SpawnEnemyUnit()
    {
        int index = Random.Range(0,3);
        Instantiate(GamePlay.Instance.enemySquad.currentPlayerUnits[index], enemyUnit.transform);
        GamePlay.Instance.enemyCount++;
    }
    private void Start()
    {
        StartCoroutine(Wait());
    }
    private void Update()
    {

        if (GamePlay.Instance.gameStatus == GameStatus.Running && 
            nextAttackTime < Time.time && 
            GamePlay.Instance.enemyCount < 3 && 
            enemyUnit != null)
        {
            SpawnEnemyUnit();
            nextAttackTime = Time.time + attackDelay;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        GamePlay.Instance.gameStatus = GameStatus.Running;
    }
}
