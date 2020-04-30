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
    [SerializeField]
    private Transform Tower;

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
                   CloseInventarButton,
                   CloseShopButton;

    [Header("Кнопки запуска View-элементов")]
    [SerializeField]
    private GameObject armyButtonView,
                       inventarView,
                       settingsView,
                       shop;

    [Header("Точки спавна текущего отряда")]
    [SerializeField]
    private GameObject[] spots = new GameObject[3];

    [SerializeField]
    private GameObject armyShop;

    [SerializeField]
    private GameObject towerUpdate;
 
    private void Start()
    {
        coinsText.text = $"{SaveLoadManager.Instance.playerData.coins}";
        energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
        GameManager.Instance.gameMode = GameMode.MainMenu;
        GameManager.Instance.UpdateTowerUpdates();
        Time.timeScale = 1f;
        cam = Camera.main;

        for(var i = 0; i < SaveLoadManager.Instance.playerData.isCurrentUnit.Length; i++)
        {
            int index = SaveLoadManager.Instance.playerData.isCurrentUnit[i];
            if (index < 0)
                spots[i] = null;
            else
                spots[i] = GameManager.Instance.allUnits[index];
        }
    }

    private void FixedUpdate()
    {
        coinsText.text = $"{SaveLoadManager.Instance.playerData.coins}";
        energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
        if (SaveLoadManager.Instance.IsCurrentSquadHasEmptySlot() &&
            (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) < 5f) && 
            !inventarView.activeSelf ||
            SaveLoadManager.Instance.IsCurrentTowerUpdateEmpty() &&
            (Mathf.Abs(cam.transform.position.x - Tower.position.x) < 5f) &&
            !inventarView.activeSelf)
        {
            armyButtonView.SetActive(true);
        }
        else
        {
            armyButtonView.SetActive(false);
        }
        if (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) > 5f &&
            Mathf.Abs(cam.transform.position.x - Tower.position.x) > 5f)
        {
            inventarView.SetActive(false);
        }
    }

    public void StartGame()
    {
        if (!SaveLoadManager.Instance.IsCurrentSquadHasEmptySlot() &&
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
        armyShop.SetActive(true);
    }

    public void CloseInventar()
    {
        inventarView.SetActive(false);
        armyButtonView.SetActive(true);
    }

    public void GetEnergy()
    {
        if(SaveLoadManager.Instance.playerData.energy<10)
            SaveLoadManager.Instance.playerData.energy++;
        energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
    }

    public void Exit()
    {
        Application.Quit();
    }
}
