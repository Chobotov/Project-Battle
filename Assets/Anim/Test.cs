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

    public void One_Button()
    {
        Debug.Log("1");
        var index = Random.Range(0, 2);
        Instantiate(players[index], pl);
    }

    public void Two_Button()
    {
        Debug.Log("2");
        var index = Random.Range(0, 2);
        Instantiate(enemys[index], enem);
    }
}
