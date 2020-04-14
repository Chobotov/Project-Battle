using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [Header("Менеджеры")]
    //Ссылки на менеджеров
    public GameObject game_manager;
    public GameObject audio_manager;
    public GameObject ui_manager;
   

    private void Awake()
    {
        if (UIManager.Instance == null)
        {
            Instantiate(ui_manager);
        }

        if (GameManager.Instance == null)
        {
            Instantiate(game_manager);
        }
        
        if(AudioManager.Instance == null)
        {
            Instantiate(audio_manager);
        }
    }
}
