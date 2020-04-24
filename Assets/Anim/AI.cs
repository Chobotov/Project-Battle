using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyUnitIndex : int
{
    Low = 0,
    Middle = 1,
    Heavy = 2
}
public enum Distance : int
{
    Near = 15,
    Middle = 25,
    Far = 50
}

public enum Choice
{
    FirstUnit,
    SecondUnit,
    ThirdUnit,
    RandomUnit,
    Mana
}
public class AI : MonoBehaviour
{
    private Choice choice;

    [Header("Единица времени готовности юнита для спавна")]
    [Range(0.1f,0.5f)]
    //Чем меньше ставить значение, тем сложнее выиграть игроку.
    public float delay;
    //Начальное значение маны
    public int mana = 150;
    //Максимальное кол-во юнитов на сцене
    public const int MAX_ENEMY_UNITS = 4;
    //Максимальное значение маны
    private const int MAX_MANA = 150;
    //Единица времени восстановления маны
    private const float manaDelay = 1f;
    //Максимальное значение готовности юнита для спавна
    private const int MAX_VALUE = 100;
    //Текущее кол-во юнитов на сцене
    public static int countUnits;
    [Header("Точка спавна юнитов")]
    public Transform  enem;
    [Header("Текущий отряд вражеских юнитов")]
    public GameObject[] enemys = new GameObject[3];
    //Массив хранит всех юнитов игрока, которые на сцене
    private GameObject[] playerUnits = new GameObject[4];
    //Расстояние от своей башни до ближайшего юнита игрока 
    float distance = float.MaxValue;
    //Текущие значения шкал заполненности кнопок
    private int currentValueFirst = MAX_VALUE;
    private int currentValueSecond = MAX_VALUE;
    private int currentValueThird = MAX_VALUE;
    private int currentValueRandom = MAX_VALUE;
    //Цены за текущих юнитов
    private int priceFirstUnit = 25;
    private int priceSecondUnit = 50;
    private int priceThirdUnit = 75;
    private int priceRandomUnit = 75;

    private void Start()
    {
        countUnits = 0;
    }

    private void FixedUpdate()
    {
        playerUnits = GameObject.FindGameObjectsWithTag("Unit");
        distance = float.MaxValue;
        for(var i = 0; i < playerUnits.Length; i++)
        {
            var UnitDistance = Mathf.Abs(playerUnits[i].transform.position.x - enem.position.x);
            if (distance > UnitDistance)
                distance = UnitDistance;
        }
        
    }

    private void Update()
    {
        if(playerUnits.Length < 4)
        {
            if (mana >= priceRandomUnit && countUnits < MAX_ENEMY_UNITS && currentValueRandom == MAX_VALUE)
            {
                Instantiate(enemys[Random.Range(0,3)], enem);
                countUnits += 1;
                currentValueRandom = 0;
                choice = Choice.RandomUnit;
                StartCoroutine(Delay());
                UseMana(priceRandomUnit);
            }
        }

        if(distance > (float)Distance.Middle && distance < (float)Distance.Far)
        {
            //Debug.Log($"Far : {distance}");
            if (mana >= priceThirdUnit  && countUnits < MAX_ENEMY_UNITS && currentValueThird == MAX_VALUE)
            {
                Instantiate(enemys[(int)EnemyUnitIndex.Heavy], enem);
                countUnits += 1;
                currentValueThird = 0;
                choice = Choice.ThirdUnit;
                StartCoroutine(Delay());
                UseMana(priceThirdUnit);
            }
        }

        else if (distance > (float)Distance.Middle && distance < (float)Distance.Far)
        {
            //Debug.Log($"Middle : {distance}");
            if (mana >= priceSecondUnit && countUnits < MAX_ENEMY_UNITS && currentValueSecond == MAX_VALUE)
            {
                Instantiate(enemys[(int)EnemyUnitIndex.Middle], enem);
                countUnits += 1;
                currentValueSecond = 0;
                choice = Choice.SecondUnit;
                StartCoroutine(Delay());
                UseMana(priceSecondUnit);
            }
        }

        else if(distance > (float)Distance.Near && distance < (float)Distance.Middle)
        {
            //Debug.Log($"Near : {distance}");
            if (mana >= priceFirstUnit  && countUnits < MAX_ENEMY_UNITS && currentValueFirst == MAX_VALUE)
            {
                Instantiate(enemys[(int)EnemyUnitIndex.Low], enem);
                countUnits += 1;
                currentValueFirst = 0;
                choice = Choice.FirstUnit;
                StartCoroutine(Delay());
                UseMana(priceFirstUnit);
            }
        }
    }


    IEnumerator Delay()
    {
        switch (choice)
        {
            case Choice.FirstUnit:
                while (currentValueFirst != MAX_VALUE)
                {
                    currentValueFirst += 1;
                    yield return new WaitForSeconds(delay);
                }
                break;
            case Choice.SecondUnit:
                while (currentValueSecond != MAX_VALUE)
                {
                    currentValueSecond += 1;
                    yield return new WaitForSeconds(delay);
                }
                break;
            case Choice.ThirdUnit:
                while (currentValueThird != MAX_VALUE)
                {
                    currentValueThird += 1;
                    yield return new WaitForSeconds(delay);
                }
                break;
            case Choice.RandomUnit:
                while (currentValueRandom != MAX_VALUE)
                {
                    currentValueRandom += 1;
                    yield return new WaitForSeconds(delay);
                }
                break;
            case Choice.Mana:
                while (mana != MAX_MANA)
                {
                    mana += 1;
                    yield return new WaitForSeconds(manaDelay);
                }
                break;
            default:
                break;
        }
    }

    private void UseMana(int value)
    {
        mana -= value;
        choice = Choice.Mana;
        StartCoroutine(Delay());
    }
}
