﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class LevelUIController : MonoBehaviour
{
    enum LevelOfSpeed
    {
        Normal,
        Faster,
        VeryFast
    }

    enum PressedButton
    {
        None,
        FirstUnit,
        SecondUnit,
        ThirdUnit,
        Mana,
        Fireball
    }

    enum GameState
    {
        Game,
        Pause,
        Win,
        Lose
    }

    public int timeDelay;

    private const int mainSceneID = 0;
    private const int loadingScreen = 1;

    private const int winCoins = 50;
    private const int loseCoins = 25;

    private const int MAX_VALUE = 100;
    private const int MAX_PLAYER_UNITS = 4;

    //Текущие значения шкал заполненности кнопок
    private int currentValueFirst = MAX_VALUE;
    private int currentValueSecond = MAX_VALUE;
    private int currentValueThird = MAX_VALUE;

    //Цены за текущих юнитов
    private int priceFirstUnit;
    private int priceSecondUnit;
    private int priceThirdUnit;

    [SerializeField]
    private Mana mana;
    [SerializeField]
    private Fireball fireball;

    [SerializeField]
    private Transform playerSpot, enemySpot;

    private GameState gameState = GameState.Game;
    private LevelOfSpeed levelOfSpeed = LevelOfSpeed.Normal;
    private PressedButton pressedButton = PressedButton.None;

    [Header("Метеорит")]
    [SerializeField]
    private GameObject meteorite;

    [SerializeField]
    private Transform meteoriteSpot;

    [Header("Панель настроек")]
    [SerializeField]
    private GameObject settingsPanel,
                       endGamePanel;

    [Header("Кнопки пауза и скорость")]
    [SerializeField]
    private Button pauseButton,
                   speedButton;

    [Header("Кнопка Fireball")]
    [SerializeField]
    private Button fireballButton;

    [Header("Кнопка Mana")]
    [SerializeField]
    private Button manaButton;

    [Header("Кнопки спавна юнитов")]
    [SerializeField]
    private Button firstUnitButton,
                   secondUnitButton,
                   thirdUnitButton;

    private float delaySpawnUnit;
    private float fireballDelay;

    [Header("Слайдеры кнопок нижней панели")]
    [SerializeField]
    private Slider firstUnitButtonSlider,
                   secondUnitButtonSlider,
                   thirdUnitButtonSlider,
                   manaButoonSlider,
                   FireballButtonSlider;

    [Header("Цена маной за спавн юнита")]
    [SerializeField]
    private Text priceManaFirstUnitText,
                 priceManaSecondUnitText,
                 priceManaThirdUnitText;

    [Header("Цена маной за увеличение макс. маны")]
    [SerializeField]
    private Text priceNextManaText;

    [Header("Вывод текущей маны и заряда фаербола")]
    [SerializeField]
    private Text textCurrentManaText,
                 textCurrentFireballText;

    [Header("Кол-во юнитов игрока на поле")]
    [SerializeField]
    private Text countUnits;
    public static int IntCountUnits;
    
    [Header("Текстовые поля панели 'Конец игры' ")]
    [SerializeField]
    private Text timeText,
                 healthText,
                 coinsText,
                 titleText;

    private Stopwatch stopwatch;

    private void Start()
    {
        mana._manaLevel = Mana_Level.First;

        priceNextManaText.text = $"{mana.MANA_PRICE}";

        stopwatch = new Stopwatch();
        stopwatch.Start();    

        IntCountUnits = 0;
        countUnits.text = $"{IntCountUnits}";

        manaButoonSlider.maxValue = mana.MAX_MANA;
        mana.MANA = (int)manaButoonSlider.maxValue;

        fireball.Value = fireball.MAX_VALUE;
        FireballButtonSlider.value = fireball.Value;

        textCurrentManaText.text = $"{mana.MANA}";
        textCurrentFireballText.text = $"{100}";

        priceFirstUnit = SaveSystem.Instance.playerData.currentUnits[0].GetComponent<UnitData>().unitProperties.ManaPrice;
        priceSecondUnit = SaveSystem.Instance.playerData.currentUnits[1].GetComponent<UnitData>().unitProperties.ManaPrice;
        priceThirdUnit = SaveSystem.Instance.playerData.currentUnits[2].GetComponent<UnitData>().unitProperties.ManaPrice;

        priceManaFirstUnitText.text = $"{priceFirstUnit}";
        priceManaSecondUnitText.text = $"{priceSecondUnit}";
        priceManaThirdUnitText.text = $"{priceThirdUnit}";
    }

    private void Update()
    {
        manaButoonSlider.maxValue = mana.MAX_MANA;
        countUnits.text = $"{IntCountUnits}";
        if (Gameplay.isPlayerTowerDead)
        {
            gameState = GameState.Lose;
            EndGame();
        }
        else if (Gameplay.isEnemyTowerDead)
        {
            gameState = GameState.Win;
            EndGame();
        }
    }

    public void Pause()
    {
        if(gameState == GameState.Game)
        {
            gameState = GameState.Pause;
            Interactable(false);
            settingsPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameState = GameState.Game;
            settingsPanel.SetActive(false);
            Interactable(true);
            Time.timeScale = 1f;
        }
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

    IEnumerator Delay()
    {
        switch (pressedButton) 
        {
            case PressedButton.FirstUnit:
                while (currentValueFirst != MAX_VALUE)
                {
                    currentValueFirst += 1;
                    firstUnitButtonSlider.value = currentValueFirst;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case PressedButton.SecondUnit:
                while (currentValueSecond != MAX_VALUE)
                {
                    currentValueSecond += 1;
                    secondUnitButtonSlider.value = currentValueSecond;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case PressedButton.ThirdUnit:
                while (currentValueThird != MAX_VALUE)
                {
                    currentValueThird += 1;
                    thirdUnitButtonSlider.value = currentValueThird;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case PressedButton.Mana:
                while (mana.MANA != (int)manaButoonSlider.maxValue)
                {
                    mana.MANA += 1;
                    manaButoonSlider.value = mana.MANA;
                    textCurrentManaText.text = $"{mana.MANA}";
                    yield return new WaitForSeconds(mana.MANA_SpeedUp);
                }
                break;
            case PressedButton.Fireball:
                while (!fireball.Fireball_isReady)
                {
                    fireball.Value += 1;
                    FireballButtonSlider.value = fireball.Value;
                    textCurrentFireballText.text = $"{fireball.Value}";
                    yield return new WaitForSeconds(1f);
                }
                break;
            default:
                break;
        }
    }

    public void SpawnFirstUnit()
    {
        if (currentValueFirst == MAX_VALUE && mana.MANA >= priceFirstUnit && IntCountUnits < MAX_PLAYER_UNITS)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[0], playerSpot);
            IntCountUnits+=1;
            currentValueFirst = 0;
            firstUnitButtonSlider.value = 0;
            pressedButton = PressedButton.FirstUnit;
            StartCoroutine(Delay());
            UseMana(priceFirstUnit);
        }
    }

    public void SpawnSecondtUnit()
    {
        if (currentValueSecond == MAX_VALUE && mana.MANA >= priceSecondUnit && IntCountUnits < MAX_PLAYER_UNITS)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[1], playerSpot);
            IntCountUnits += 1;
            currentValueSecond = 0;
            secondUnitButtonSlider.value = 0;
            pressedButton = PressedButton.SecondUnit;
            StartCoroutine(Delay());
            UseMana(priceSecondUnit);
        }
    }

    public void SpawnThirdUnit()
    {
        if (currentValueThird == MAX_VALUE && mana.MANA >= priceThirdUnit && IntCountUnits < MAX_PLAYER_UNITS)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[2], playerSpot);
            IntCountUnits += 1;
            currentValueThird = 0;
            thirdUnitButtonSlider.value = 0;
            pressedButton = PressedButton.ThirdUnit;
            StartCoroutine(Delay());
            UseMana(priceThirdUnit);
        }
    }

    public void ManaButton()
    {
        if(mana.MANA >= mana.MANA_PRICE && mana._manaLevel != Mana_Level.Third)
        {
            int manaPrice = mana.MANA_PRICE;
            mana.NextManaLevel();
            priceNextManaText.text = $"{mana.MANA_PRICE}";
            UseMana(manaPrice);
        }
    }

    public void Fireball()
    {
        if (fireball.Fireball_isReady)
        {
            Instantiate(meteorite, meteoriteSpot);
            fireball.Value = 0;
            FireballButtonSlider.value = 0;
            pressedButton = PressedButton.Fireball;
            StartCoroutine(Delay());
        }
    }

    public void Continue()
    {
        switch (gameState)
        {
            case GameState.Win:
                SaveSystem.Instance.playerData.coins += winCoins;
                break;
            case GameState.Lose:
                SaveSystem.Instance.playerData.coins -= loseCoins;
                break;
        }
        AsyncLoadingScreen.sceneID = mainSceneID;
        SceneManager.LoadScene(loadingScreen);
    }

    private void EndGame()
    {
        stopwatch.Stop();
        StopAllCoroutines();
        Interactable(false);
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = $"{ts.Minutes}:{ts.Seconds}";

        switch (gameState)
        {
            case GameState.Win:
                titleText.text = "Победа!";
                timeText.text = elapsedTime;
                healthText.text = $"{Gameplay.playerHealth}";
                coinsText.text = $"+{winCoins}";
                endGamePanel.SetActive(true);
                break;
            case GameState.Lose:
                titleText.text = "Проиграл сражение, но не войну!";
                timeText.text = elapsedTime;
                healthText.text = $"{Gameplay.playerHealth}";
                coinsText.text = $"-{loseCoins}";
                endGamePanel.SetActive(true);
                break;

        }
    }

    private void Interactable(bool On_Off)
    {
        manaButton.interactable = On_Off;
        fireballButton.interactable = On_Off;
        firstUnitButton.interactable = On_Off;
        secondUnitButton.interactable = On_Off;
        thirdUnitButton.interactable = On_Off;
        pauseButton.gameObject.SetActive(On_Off);
        speedButton.gameObject.SetActive(On_Off);
    }

    private void UseMana(int value)
    {
        mana.MANA -= value;
        manaButoonSlider.value = mana.MANA;
        pressedButton = PressedButton.Mana;
        StartCoroutine(Delay());
    }

}
