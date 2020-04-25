using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> allUnits = new List<GameObject>();

    public List<GameObject> towerUpdates = new List<GameObject>();
}
