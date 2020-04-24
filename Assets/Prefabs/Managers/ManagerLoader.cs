using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    // Ссылки на менеджеров
    public GameObject game_manager; 
    public GameObject save_manager; 


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
    }
}
