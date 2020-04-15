using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    Start,
    Running,
    Pause,
    Win,
    GameOver
}
public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance;

    public GameStatus gameStatus;
    [Header("Данные об игроке")]
    public Mana mana;
    public Fireball fireball;
    [Header("Юниты врага")]
    public Squad enemySquad;
    [Header("Текущее кол-во юнитов врага на сцене")]
    public int enemyCount;
    [Header("Текущее кол-во юнитов врага на сцене")]
    public int playerCount;

    private UnitData playerTowerData,enemyTowerData;

    public Text txt;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        gameStatus = GameStatus.Start;
        enemyCount = 0;
        playerCount = 0;
        playerTowerData = GameObject.Find("PlayerTower").GetComponent<UnitData>();
        enemyTowerData = GameObject.Find("EnemyTower").GetComponent<UnitData>();

        mana.MANA = 0;

        txt.text = ($"1 : {GameManager.Instance.playerData.squad.currentPlayerUnits[1]}");
    }
    private void Update()
    {
        if(enemyCount > 0 || playerCount > 0)
        {
            gameStatus = GameStatus.Running;
        }
        //Игра идет пока башня игрока не уничтожена
        if (gameStatus == GameStatus.Running)
        {
            //Debug.Log("Running!");
            if (playerTowerData.unit.dataHealth.isDead)
            {
                gameStatus = GameStatus.GameOver;
            }
        }
        //Игра на паузе
        else if (gameStatus == GameStatus.Pause)
        {
            //Debug.Log("Pause!");
        }
        //Игрок победил
        else if(gameStatus == GameStatus.Win)
        {
            //Debug.Log("Win!");
        }
        //Игрок проиграл
        else if(gameStatus == GameStatus.GameOver)
        {
            //Debug.Log("Game Over!");
        }
    }
}
