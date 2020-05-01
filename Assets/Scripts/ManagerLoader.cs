using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField]
    AudioClip mainMenu;
    [SerializeField]
    AudioClip level;
    [SerializeField]
    AudioClip buttonClick;
    [SerializeField]
    AudioClip buyButtonClick;
    [SerializeField]
    AudioClip meteorExplosion;
    [SerializeField]
    AudioClip[] fireballAudio = new AudioClip[3];
    [SerializeField]
    AudioClip swordsdFight;
    [SerializeField]
    AudioClip punch;
    [SerializeField]
    AudioClip[] death = new AudioClip[3];
    [SerializeField]
    AudioClip win;
    [SerializeField]
    AudioClip lose;
    AudioSource audioSource;
    [Space]
    // Ссылки на менеджеров
    public GameObject game_manager; 
    public GameObject save_manager;
    public GameObject audio_manager;

    [Header("UNITS AND ITEMS")]
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
        if (AudioManager.Instance == null)
        {
            Instantiate(audio_manager);
        }
        if (GameManager.Instance.allUnits.Count == 0)
            GameManager.Instance.allUnits.AddRange(units);
        if (GameManager.Instance.towerUpdates.Count == 0)
            GameManager.Instance.towerUpdates.AddRange(towerUpdates);
        if (GameManager.Instance.spotTowerUpdate == null)
            GameManager.Instance.spotTowerUpdate = this.spotTowerUpdate;

        AudioManager.Instance.mainMenu = mainMenu;
        AudioManager.Instance.level = level;
        AudioManager.Instance.buttonClick = buttonClick;
        AudioManager.Instance.buyButtonClick = buyButtonClick;
        AudioManager.Instance.meteorExplosion = meteorExplosion;
        
        AudioManager.Instance.fireballAudio[0] = fireballAudio[0];
        AudioManager.Instance.fireballAudio[1] = fireballAudio[1];
        AudioManager.Instance.fireballAudio[2] = fireballAudio[2];

        AudioManager.Instance.swordsdFight = swordsdFight;
        AudioManager.Instance.punch = punch;
       
        AudioManager.Instance.death[0] = death[0];
        AudioManager.Instance.death[1] = death[1];
        AudioManager.Instance.death[2] = death[2];
        
        AudioManager.Instance.win = win;
        AudioManager.Instance.lose = lose;

    }
}
