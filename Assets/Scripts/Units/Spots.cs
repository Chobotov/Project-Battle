using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spots : MonoBehaviour
{
    public GameObject[] spots = new GameObject[3];

    private void FixedUpdate()
    {
        UpdateSpots();
    }

    //Обновление текущего отряда
    public void UpdateSpots()
    {
        for (var i = 0; i < spots.Length; i++)
        {
            if (SaveLoadManager.Instance.playerData.currentUnits[i] != null)
                spots[i].GetComponent<SpriteRenderer>().sprite = SaveLoadManager.Instance.playerData.currentUnits[i].GetComponent<SpriteRenderer>().sprite;
            else
                spots[i].GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
