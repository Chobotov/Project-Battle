using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button player, enemy;
    public Transform pl, enem;
    public GameObject[] players = new GameObject[3];
    public GameObject[] enemys = new GameObject[3];

    public float Delay;

    private void Update()
    {
        if(Delay < Time.time)
        {
            int index = Random.Range(0,3);
            Instantiate(enemys[index],enem);
            Delay = Time.time + Delay;
        }
    }
}
