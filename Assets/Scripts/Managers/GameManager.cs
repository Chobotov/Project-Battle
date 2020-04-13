using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{   
    public Mana mana;
    public Fireball fireball;
    //Башни на сцене
    public GameObject PlayerTower, EnemyTower;
    //Массив юнитов игрока
    public GameObject[] _playerUnits = new GameObject[3];
    //Массив юнитов врага
    public GameObject[] _enemyUnits = new GameObject[3];


    [SerializeField] private Button manaButton;
    [SerializeField] private Text manaLevel;

    private void Update()
    {
        if (!mana.MANA_isFull)
        {
            mana.MANA += 1;
            manaLevel.text = mana.MANA.ToString();
        }
    }
}
