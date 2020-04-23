using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button player, 
                  enemy;
    public Transform pl, 
                     enem;
    public GameObject[] players = new GameObject[3];
    public GameObject[] enemys = new GameObject[3];

    public float Delay = 3, nextSpawn;

    private void Update()
    {
        if(nextSpawn < Time.time)
        {
            int index = 0; //Random.Range(0,1);
            Instantiate(enemys[index],enem);
            nextSpawn = Time.time + Delay;
        }
    }
}
