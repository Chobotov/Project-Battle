using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UnitDataBase
{
    public List<GameObject> allUnits = new List<GameObject>();

    public void SetAllUnits(List<GameObject> allUnits)
    {
        this.allUnits.AddRange(allUnits);
    }
}
