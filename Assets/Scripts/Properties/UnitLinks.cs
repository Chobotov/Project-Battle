using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLinks : MonoBehaviour
{
    [HideInInspector]public UnitData unitData;

    private void Awake()
    {
        unitData = GetComponent<UnitData>();
    }
}
