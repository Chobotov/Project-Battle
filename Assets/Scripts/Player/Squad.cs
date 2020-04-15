using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Squad : ScriptableObject
{
    /// <summary>
    /// Все имеющиеся юниты 
    /// </summary>
    public List<Unit> allUnits;
    /// <summary>
    /// Текущий отряд 
    /// </summary>
    public Unit[] currentPlayerUnits = new Unit[3];
}
