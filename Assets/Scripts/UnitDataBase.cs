using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UnitDataBase 
{
    public List<GameObject> purchasedUnits = new List<GameObject>();
    public List<GameObject> allUnits = new List<GameObject>();

    public void SetPurchasedUnits(List<GameObject> purchasedUnits)
    {
        this.purchasedUnits.AddRange(purchasedUnits);
    }

    public void SetAllUnits(List<GameObject> allUnits)
    {
        this.allUnits.AddRange(allUnits);
    }
}
