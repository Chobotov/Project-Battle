using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject soilder;
    private Vector3 localScale;
    private float health;

    private void Start()
    {
        localScale = transform.localScale;
        health = soilder.GetComponent<DataHealth>().health;
    }

    private void Update()
    {
        localScale.x = health/100;
        transform.localScale = localScale;
    }
}
