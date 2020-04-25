using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timely : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;

    private void Start()
    {
        SaveLoadManager.Instance.playerData.currentUnits[0] = first;
        SaveLoadManager.Instance.playerData.currentUnits[1] = second;
        SaveLoadManager.Instance.playerData.currentUnits[2] = third;
    }
}
