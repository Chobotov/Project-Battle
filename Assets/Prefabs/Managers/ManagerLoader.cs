using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    public UnitDataBase unitDataBase;
    public PlayerData playerData;

    // Ссылки на менеджеров
    public GameObject game_manager; // Game Base Manager

    // Метод пробуждения объекта (перед стартом игры)
    void Awake()
    {
        // Инициализация игровой базы
        if (GameManager.Instance == null)
        {
            Instantiate(game_manager);
        }
    }

    private void Start()
    {
        int coins = playerData.coins;
        int energy = playerData.energy;
        GameObject[] currentUnits = playerData.currentUnits;
        GameObject currentTowerUpdate = playerData.currentTowerUpdate;
        playerData = ScriptableObject.CreateInstance(typeof(PlayerData)) as PlayerData;
        playerData.SetCoinsAndEnergy(coins, energy);
        playerData.SetCurrentUnits(currentUnits);
        playerData.SetCurrentTowerUpdate(currentTowerUpdate);

        List<GameObject> purchasedUnits = new List<GameObject>();
        List<GameObject> allUnits = new List<GameObject>();

        purchasedUnits.AddRange(unitDataBase.purchasedUnits);
        allUnits.AddRange(unitDataBase.allUnits);
        unitDataBase = ScriptableObject.CreateInstance(typeof(UnitDataBase)) as UnitDataBase;
        unitDataBase.SetPurchasedUnits(purchasedUnits);
        unitDataBase.SetAllUnits(allUnits);

        GameManager.Instance.unitDataBase = unitDataBase;
        GameManager.Instance.playerData = playerData;
    }
}
