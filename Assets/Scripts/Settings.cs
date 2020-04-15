using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Unit unit;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = unit.sprite;
    }
}
