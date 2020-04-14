using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    /// <summary>
    /// Отряд
    /// </summary>
    public Squad squad;
    //Энергия игрока
    private int energy = 10;
    public int Energy
    {
        get
        {
            return energy;
        }

        set
        {
            energy += value;
        }
    }

    //Монеты игрока
    private int money = 0;
    public int Money
    {
        get
        {
            return money;
        }

        set
        {
            money += value;
        }
    }
}
