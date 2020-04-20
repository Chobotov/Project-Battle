using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitDataBase : ScriptableObject
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
