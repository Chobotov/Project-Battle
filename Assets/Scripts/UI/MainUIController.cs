using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
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
    private Button StartButton,
                   SettingsButton,
                   ArmyButton,
                   InventarButton;

    [Header("Кнопки закрытия View-элементов")]
    [SerializeField]
    private Button CloseSettingsButton,
                   CloseTowerUpdatesButton,
                   CloseInventarButton;

    [Header("Кнопки запуска View-элементов")]
    [SerializeField]
    private GameObject armyButtonView,
                       InventarView,
                       SettingsView;

    private void Start()
    {
        cam = Camera.main;
        Debug.Log(SaveSystem.Instance.playerData);
        energyText.text = SaveSystem.Instance.playerData.energy.ToString();
        coinsText.text = SaveSystem.Instance.playerData.coins.ToString();
    }

    private void FixedUpdate()
    {
        if (CurrentUnitsIsEmpty(SaveSystem.Instance.playerData.currentUnits) &&
            (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) < 5f)
            && !InventarView.activeSelf)
        {
            armyButtonView.SetActive(true);
        }
        else
        {
            armyButtonView.SetActive(false);
        }
        if (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) > 5f)
        {
            InventarView.SetActive(false);
        }
    }

    public void StartGame()
    {
        if (SaveSystem.Instance.playerData.currentUnits[0] != null &&
           SaveSystem.Instance.playerData.currentUnits[1] != null &&
            SaveSystem.Instance.playerData.currentUnits[2] != null &&
            SaveSystem.Instance.playerData.energy > 0)
        {
            SaveSystem.Instance.playerData.energy -= 1;
            SceneManager.LoadScene(sceneID);
        }
    }

    public void ShowSettings()
    {
        SettingsView.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsView.SetActive(false);
    }

    public void ShowInventar()
    {
        InventarView.SetActive(true);
        armyButtonView.SetActive(false);
    }

    public void CloseInventar()
    {
        InventarView.SetActive(false);
        armyButtonView.SetActive(true);
    }

    public void GetEnergy()
    {
        SaveSystem.Instance.playerData.energy++;
        energyText.text = SaveSystem.Instance.playerData.energy.ToString();
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
