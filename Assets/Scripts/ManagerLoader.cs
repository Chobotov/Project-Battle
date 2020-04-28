using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    // Ссылки на менеджеров
    public GameObject game_manager; 
    public GameObject save_manager;

    //Юниты
    [SerializeField]
    private List<GameObject> units = new List<GameObject>();

    //Улучшения для башни
    [SerializeField]
    private List<GameObject> towerUpdates = new List<GameObject>();

    public Transform spotTowerUpdate;


    // Метод пробуждения объекта (перед стартом игры)
    void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(game_manager);
        }

        if (SaveLoadManager.Instance == null)
        {
            Instantiate(save_manager);
        }
        if(GameManager.Instance.allUnits.Count == 0)
            GameManager.Instance.allUnits.AddRange(units);
        if (GameManager.Instance.towerUpdates.Count == 0)
            GameManager.Instance.towerUpdates.AddRange(towerUpdates);
        if (GameManager.Instance.spotTowerUpdate == null)
            GameManager.Instance.spotTowerUpdate = this.spotTowerUpdate;
    }
}
