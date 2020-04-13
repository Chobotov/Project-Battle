using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Fireball : ScriptableObject
{
    //Шкала накопления 
    public Slider FireballSlider;
    //Урон 
    [SerializeField] private int damage = 250;
    public int Damage
    {
        get
        {
            return damage;
        }
    }
    //Текущее значение шкалы накопления
    private int currentValue = 0;
    public int Value
    {
        get
        {
            return currentValue;
        }
    }
    //Максимальное значение шкалы
    [SerializeField]private int MaxValue = 100;
    //Заклинание готово
    private bool IsReady;
    public bool Fireball_isReady
    {
        get
        {
            return currentValue == MaxValue ? true : false;
        }
    }

    

}
