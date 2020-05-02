using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    private const int loadScene = 2;
    private const int coinsPrice = 10;

    [Header("Туториал")]
    [SerializeField]
    private GameObject tutorial;

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

    [Header("Спрайты кнопки ВКЛ/ВЫКЛ звука")]
    [SerializeField]
    private Sprite onButton,oFFButton;

    private void Start()
    {
        if (SaveLoadManager.Instance.playerData.isFirstLaunch)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }

        AudioManager.Instance.AudioSource.Stop();
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.MainMenu);

        coinsText.text = $"{SaveLoadManager.Instance.playerData.coins}";
        if(SaveLoadManager.Instance.playerData.energy > 10)
            energyText.text = $"{SaveLoadManager.Instance.playerData.energy}";
        
        GameManager.Instance.gameMode = GameMode.MainMenu;
        GameManager.Instance.UpdateTowerUpdates();
        
        Time.timeScale = 1f;
        
        cam = Camera.main;

        switch (AudioManager.Instance.audioStatus)
        {
            case AudioStatus.ON:
                OnOffAudioButton.GetComponent<Image>().sprite = onButton;
                break;
            case AudioStatus.OFF:
                OnOffAudioButton.GetComponent<Image>().sprite = oFFButton;
                break;
        }

        for (var i = 0; i < SaveLoadManager.Instance.playerData.isCurrentUnit.Length; i++)
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
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
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
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        settingsView.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        settingsView.SetActive(false);
    }

    public void ShowInventar()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        inventarView.SetActive(true);
        armyButtonView.SetActive(false);
    }

    public void CloseShop()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        shop.SetActive(false);
        armyShop.SetActive(true);
    }

    public void CloseInventar()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        inventarView.SetActive(false);
        armyButtonView.SetActive(true);
    }

    public void OnOffAudio()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        switch (AudioManager.Instance.audioStatus)
        {
            case AudioStatus.ON:
                OnOffAudioButton.GetComponent<Image>().sprite = oFFButton;
                AudioManager.Instance.AudioSource.volume = 0f;
                AudioManager.Instance.audioStatus = AudioStatus.OFF;
                break;
            case AudioStatus.OFF:
                OnOffAudioButton.GetComponent<Image>().sprite = onButton;
                AudioManager.Instance.AudioSource.volume = 1f;
                AudioManager.Instance.audioStatus = AudioStatus.ON;
                break;
        }
    }

    public void GetEnergy()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        if (SaveLoadManager.Instance.playerData.energy<10 && SaveLoadManager.Instance.playerData.coins >= coinsPrice)
        {
            SaveLoadManager.Instance.playerData.energy++;
            SaveLoadManager.Instance.playerData.coins -= coinsPrice;
            
        }
    }

    public void Exit()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        Application.Quit();
    }
}
