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
        Pause
    }

    public int timeDelay;

    private const int MAX_VALUE = 100;

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
    private Transform playerSpot, enemySpot;

    private GameState gameState = GameState.Game;
    private LevelOfSpeed levelOfSpeed = LevelOfSpeed.Normal;
    private PressedButton pressedButton = PressedButton.None;

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

    [SerializeField]
    private Slider firstUnitButtonSlider,
                   secondUnitButtonSlider,
                   thirdUnitButtonSlider,
                   manaButoonSlider,
                   FireballButtonSlider;

    [SerializeField]
    private Text textCurrentMana,
                 textCurrentFireball;

    private void Start()
    {
        mana._manaLevel = Mana_Level.First;

        manaButoonSlider.maxValue = mana.MAX_MANA;
        mana.MANA = (int)manaButoonSlider.maxValue;

        textCurrentMana.text = mana.MANA.ToString();
        textCurrentFireball.text = 100.ToString();

        priceFirstUnit = SaveSystem.Instance.playerData.currentUnits[0].GetComponent<UnitData>().unitProperties.ManaPrice;
        priceSecondUnit = SaveSystem.Instance.playerData.currentUnits[1].GetComponent<UnitData>().unitProperties.ManaPrice;
        priceThirdUnit = SaveSystem.Instance.playerData.currentUnits[2].GetComponent<UnitData>().unitProperties.ManaPrice;
    }

    private void Update()
    {
        manaButoonSlider.maxValue = mana.MAX_MANA;
    }

    public void Pause()
    {
        if(gameState == GameState.Game)
        {
            gameState = GameState.Pause;
            speedButton.gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
            Time.timeScale = 0f;
        }
        else
        {
            gameState = GameState.Game;
            speedButton.gameObject.SetActive(true);
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
                    textCurrentMana.text = mana.MANA.ToString();
                    yield return new WaitForSeconds(mana.MANA_SpeedUp);
                }
                break;
            //case PressedButton.Fireball:
            //    while (currentValueFirst != MAX_VALUE)
            //    {
            //        currentValueFirst += 1;
            //        slider.value = currentValueFirst;
            //        yield return null;
            //    }
            //    break;
            default:
                break;
        }
    }

    public void SpawnFirstUnit()
    {
        if (currentValueFirst == MAX_VALUE && mana.MANA >= priceFirstUnit)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[0], playerSpot);
            currentValueFirst = 0;
            firstUnitButtonSlider.value = 0;
            pressedButton = PressedButton.FirstUnit;
            StartCoroutine(Delay());
            UseMana(priceFirstUnit);
        }
    }

    public void SpawnSecondtUnit()
    {
        if (currentValueSecond == MAX_VALUE && mana.MANA >= priceSecondUnit)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[1], playerSpot);
            currentValueSecond = 0;
            secondUnitButtonSlider.value = 0;
            pressedButton = PressedButton.SecondUnit;
            StartCoroutine(Delay());
            UseMana(priceSecondUnit);
        }
    }

    public void SpawnThirdUnit()
    {
        if (currentValueThird == MAX_VALUE && mana.MANA >= priceThirdUnit)
        {
            Instantiate(SaveSystem.Instance.playerData.currentUnits[2], playerSpot);
            currentValueThird= 0;
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
            UseMana(manaPrice);
        }
    }

    private void UseMana(int value)
    {
        mana.MANA -= value;
        manaButoonSlider.value = mana.MANA;
        pressedButton = PressedButton.Mana;
        StartCoroutine(Delay());
    }
}
