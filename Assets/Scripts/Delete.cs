using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public int id;
    private void OnMouseDown()
    {
        SaveLoadManager.Instance.playerData.currentUnits[id] = null;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
