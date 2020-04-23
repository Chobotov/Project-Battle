using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataHealth : ScriptableObject
{
    [Header("Жизнь")]
    [Range(0, 100)]
    public int Health = 100;


    public void SetHealth(int health)
    {
        Health = health;
    }
}
