using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    //Ссылки на менеджеров
    public GameObject game_manager;
    public GameObject audio_manager;


    private void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(game_manager);
        }
        
        if(AudioManager.instance == null)
        {
            Instantiate(audio_manager);
        }
    }

}
