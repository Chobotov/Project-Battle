using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class DataHealth : ScriptableObject
{
    [Header ("Здоровье")]
    public float health;
    [Header ("Смерть")]
    public bool isDead;
}
