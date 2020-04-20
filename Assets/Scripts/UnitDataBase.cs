using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitDataBase : ScriptableObject
{
    public List<GameObject> buyUnits = new List<GameObject>();
    public List<GameObject> allUnits = new List<GameObject>();
}
