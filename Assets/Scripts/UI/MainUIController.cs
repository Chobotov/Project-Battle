using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    private const int loadScene = 2;

    private Camera cam;
    [SerializeField]
    private Transform SquadSpot;

    [Header("Загружаемая сцена")]
    public int sceneID;

    [Header("Текущая энергия и монеты")]
    [SerializeField]
    private Text energyText,
                 coinsText;

    [Header("Вкл/Выкл звук")]
    [SerializeField]
    private Button OnOffAudioButton;

    [Header("Кнопки нижней части экрана")]
    [SerializeField]
    private Button startButton,
                   settingsButton,
                   exitButton;

    [Header("Кнопки закрытия View-элементов")]
    [SerializeField]
    private Button CloseSettingsButton,
                   CloseTowerUpdatesButton,
                   CloseInventarButton;

    [Header("Кнопки запуска View-элементов")]
    [SerializeField]
    private GameObject armyButtonView,
                       inventarView,
                       settingsView,
                       shop;

    private void Start()
    {
        Time.timeScale = 1f;
        cam = Camera.main;
        energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
        coinsText.text = $"{SaveLoadManager.Instance.playerData.coins}";
    }

    private void FixedUpdate()
    {
        if (CurrentUnitsIsEmpty(SaveLoadManager.Instance.playerData.currentUnits) &&
            (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) < 5f)
            && !inventarView.activeSelf)
        {
            armyButtonView.SetActive(true);
        }
        else
        {
            armyButtonView.SetActive(false);
        }
        if (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) > 5f)
        {
            inventarView.SetActive(false);
        }
    }

    public void StartGame()
    {
        if (SaveLoadManager.Instance.playerData.currentUnits[0] != null &&
           SaveLoadManager.Instance.playerData.currentUnits[1] != null &&
            SaveLoadManager.Instance.playerData.currentUnits[2] != null &&
            SaveLoadManager.Instance.playerData.energy > 0)
        {
            SaveLoadManager.Instance.playerData.energy -= 1;
            AsyncLoadingScreen.sceneID = loadScene;
            SceneManager.LoadScene(sceneID);
        }
    }

    public void ShowSettings()
    {
        settingsView.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsView.SetActive(false);
    }

    public void ShowInventar()
    {
        inventarView.SetActive(true);
        armyButtonView.SetActive(false);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void CloseInventar()
    {
        inventarView.SetActive(false);
        armyButtonView.SetActive(true);
    }

    public void GetEnergy()
    {
        SaveLoadManager.Instance.playerData.energy++;
        energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
    }

    public void Exit()
    {
        Application.Quit();
    }

    private bool CurrentUnitsIsEmpty(GameObject[] currentUnits)
    {
        bool isEmpty = false;
        for(var i = 0; i < currentUnits.Length; i++)
        {
            if (currentUnits[i] == null)
                isEmpty = true;
        }
        return isEmpty;

    }
}
