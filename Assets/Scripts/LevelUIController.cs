using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    [Header("Кнопки пауза и скорость")]
    [SerializeField]
    private Button pauseButton,
                   SpeedButton;

    [Header("Кнопка Fireball")]
    [SerializeField]
    private Button fireballButton;

    [Header("Кнопка Mana")]
    [SerializeField]
    private Button manaButton;

    [Header("Кнопки спавна юнитов")]
    [SerializeField]
    private Button firstUnit,
                   secondUnit,
                   thirdUnit;

    private float delaySpawnUnit;
    private float fireballDelay;

}
