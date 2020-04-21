using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    public UnitDataBase unitDataBase;
    public PlayerData playerData;

    // Ссылки на менеджеров
    public GameObject game_manager; 
    public GameObject save_manager; 


    // Метод пробуждения объекта (перед стартом игры)
    void Awake()
    {
        // Инициализация игровой базы
        if (GameManager.Instance == null)
        {
            Instantiate(game_manager);
        }

        // Инициализация игровой базы
        if (SaveSystem.Instance == null)
        {
            Instantiate(save_manager);
        }
    }

    private void Start()
    {
        List<GameObject> purchasedUnits = new List<GameObject>();
        List<GameObject> allUnits = new List<GameObject>();

        purchasedUnits.AddRange(unitDataBase.purchasedUnits);
        allUnits.AddRange(unitDataBase.allUnits);
        unitDataBase = ScriptableObject.CreateInstance(typeof(UnitDataBase)) as UnitDataBase;
        unitDataBase.SetPurchasedUnits(purchasedUnits);
        unitDataBase.SetAllUnits(allUnits);

        GameManager.Instance.unitDataBase = unitDataBase;
    }
}
