using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    public UnitDataBase unitDataBase;

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
}
