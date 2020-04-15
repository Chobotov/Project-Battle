using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main main;
    public const int MAX_UNITS_IN_SQUAD = 3;
    public GameObject [] currentPlayerUnits;
    [SerializeField] private Transform[] squadSpots = new Transform[MAX_UNITS_IN_SQUAD];

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        Debug.Log(GameManager.Instance);
        Debug.Log(GameManager.Instance.playerData);
        Debug.Log(GameManager.Instance.playerData.squad);
        currentPlayerUnits = new GameObject[MAX_UNITS_IN_SQUAD];
        SetSquad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSquad()
    {
        for (var i = 0; i < MAX_UNITS_IN_SQUAD; i++)
        {
            var unit = GameManager.Instance.playerData.squad.currentPlayerUnits[i];
            if (unit != null && currentPlayerUnits[i] == null)
            {
                //currentPlayerUnits[i] = Instantiate(unit, squadSpots[i]);
                //currentPlayerUnits[i].GetComponent<PlayerUnitAI>().enabled = false;
            }
        }
    }
}
