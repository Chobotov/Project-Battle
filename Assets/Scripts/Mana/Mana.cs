using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Уровень максимальной маны
public enum Mana_Level
{
    First,
    Second,
    Third
}

[CreateAssetMenu]
public class Mana : ScriptableObject
{
    public Mana_Level _manaLevel = Mana_Level.First;
    //Кол-во текущей маны
    private int _currentMana = 0;
    public int MANA
    {
        get
        {
            return _currentMana;
        }
        set
        {
            _currentMana = value;
        }
    }
    //Мана заполнена
    private bool isFull;
    public bool MANA_isFull
    {
        get
        {
            return _currentMana == MAX_MANA ? true : false;
        }
    }
    //Цена для повышения уровня максимальной маны
    private int _manaPrice;
    public int MANA_PRICE
    {
        get
        {
            switch (_manaLevel)
            {

                case Mana_Level.First:
                    _manaLevel = Mana_Level.Second;
                    return 75;
                case Mana_Level.Second:
                    _manaLevel = Mana_Level.Third;
                    return 150;
                case Mana_Level.Third:
                    return 300;
                default:
                    return 0;
            }
        }
    } 
    //Кол-во максимальной маны
    public int MAX_MANA
    {
        get
        {
            switch (_manaLevel)
            {
                case Mana_Level.First:
                    return 100;
                case Mana_Level.Second:
                    return 200;
                case Mana_Level.Third:
                    return 300;
                default:
                    return 0;
            }
        }
    }
}
