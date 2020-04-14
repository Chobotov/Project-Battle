using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Squad : ScriptableObject
{
    /// <summary>
    /// Все имеющиеся юниты 
    /// </summary>
    public Queue<GameObject> allUnits = new Queue<GameObject>();
    /// <summary>
    /// Текущий отряд 
    /// </summary>
    public GameObject[] currentPlayerUnits = new GameObject[3];
}
