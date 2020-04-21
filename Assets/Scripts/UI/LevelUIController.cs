using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    enum LevelOfSpeed
    {
        Normal,
        Faster,
        VeryFast
    }

    public int timeDelay;

    private const int MAX_VALUE = 100;

    public int currentValueFirst = MAX_VALUE;
    public int currentValueSecond = MAX_VALUE;
    public int currentValueThird = MAX_VALUE;

    [SerializeField]
    private Transform playerSpot, enemySpot;

    private LevelOfSpeed levelOfSpeed = LevelOfSpeed.Normal;

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

    [SerializeField]
    private Slider firstUnitButtonSlider,
                   secondUnitButtonSlider,
                   thirdUnitButtonSlider;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void Pause()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 0f;
    }

    public void Speed()
    {
        switch (levelOfSpeed)
        {
            case LevelOfSpeed.Normal:
                levelOfSpeed = LevelOfSpeed.Faster;
                Time.timeScale = 1.5f;
                break;
            case LevelOfSpeed.Faster:
                levelOfSpeed = LevelOfSpeed.VeryFast;
                Time.timeScale = 2f;
                break;
            case LevelOfSpeed.VeryFast:
                levelOfSpeed = LevelOfSpeed.Normal;
                Time.timeScale = 1f;
                break;
        }
    }

    IEnumerator Delay(int currentValue, Slider slider)
    {
        while(currentValueFirst != MAX_VALUE)
        {
            currentValueFirst += 1;
            slider.value = currentValueFirst;
            yield return null;
        }
    }

    public void SpawnFirstUnit()
    {
        Debug.Log(SaveSystem.Instance);
        if (currentValueFirst == MAX_VALUE)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[0], playerSpot);
            currentValueFirst = 0;
            firstUnitButtonSlider.value = 0;
        }
        else
        {
            StartCoroutine(Delay(currentValueFirst,firstUnitButtonSlider));
        }
    }

    public void SpawnSecondtUnit()
    {
        Debug.Log(SaveSystem.Instance.playerData);
        if (currentValueSecond == MAX_VALUE)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[1], playerSpot);
            currentValueSecond = 0;
            secondUnitButtonSlider.value = 0;
        }
        else
        {
            StartCoroutine(Delay(currentValueSecond, secondUnitButtonSlider));
        }
    }

    public void SpawnThirdUnit()
    {
        Debug.Log(SaveSystem.Instance.playerData);
        if (currentValueThird == MAX_VALUE)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[2], playerSpot);
            currentValueThird= 0;
            thirdUnitButtonSlider.value = 0;
        }
        else
        {
            StartCoroutine(Delay(currentValueThird, thirdUnitButtonSlider));
        }
    }
}
