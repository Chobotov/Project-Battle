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
    private Text energy,
                 coins;

    [Header("Вкл/Выкл звук")]
    [SerializeField]
    private Button OnOffAudio;

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
        energy.text = GameManager.Instance.playerData.energy.ToString();
        coins.text = GameManager.Instance.playerData.coins.ToString();
    }

    private void FixedUpdate()
    {
        if (CurrentUnitsIsEmpty(GameManager.Instance.playerData.currentUnits) && 
            (Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) < 5f)
            && !InventarView.activeSelf)
        {
            armyButtonView.SetActive(true);
        }
        else
        {
            armyButtonView.SetActive(false);
        }
        if(Mathf.Abs(cam.transform.position.x - SquadSpot.position.x) > 5f)
        {
            InventarView.SetActive(false);
        }
    }

    public void StartGame()
    {
        //if(GameManager.Instance.playerData.squad.currentPlayerUnits[0] != null &&
        //    GameManager.Instance.playerData.squad.currentPlayerUnits[1] != null &&
        //    GameManager.Instance.playerData.squad.currentPlayerUnits[2] != null)
        //{
        SceneManager.LoadScene(sceneID);
        //}
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
