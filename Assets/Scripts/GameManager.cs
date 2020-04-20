using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UnitDataBase unitDataBase;
    public GameObject Item;
    public PlayerData playerData;
    void Start()
    {
        SetData();
    }

    private void SetData() 
    {
        if(unitDataBase.buyUnits.Count == 0)
        {
            for (var i = 0; i < unitDataBase.allUnits.Count; i++)
            {
                if (unitDataBase.allUnits[i].GetComponent<UnitData>().unitProperties.isPurchased)
                {
                    unitDataBase.buyUnits.Add(unitDataBase.allUnits[i]);
                }
            }
        }
    }

}
