using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [Header("Башни")]
    [SerializeField]
    private GameObject PlayerTower,
                       EnemyTower;
    [Header("Взрыв")]
    [SerializeField]
    private GameObject Explosion;

    [Header("TowerUpdate")]
    [SerializeField]
    private GameObject towerUpdate;
    public GameObject spotTowerUpdate;

    private UnitData playerUnitData,
                     enemyUnitData;

    public static int playerHealth;

    [Header("X-координата взрыва")]
    [SerializeField]
    private float X_PlayerCord,
                  X_EnemyCord;
    private float Ycord = 5f;

    public static bool isEnemyTowerDead;
    public static bool isPlayerTowerDead;

    private GameObject currentTowerUpdate;

    void Start()
    {
        GameManager.Instance.gameMode = GameMode.Level;
        CheckTowerUpdate();
        isEnemyTowerDead = false;
        isPlayerTowerDead = false;
        playerUnitData = PlayerTower.GetComponent<UnitData>();
        enemyUnitData = EnemyTower.GetComponent<UnitData>();
    }

    void Update()
    {
        playerHealth = playerUnitData.dataHealth.Health;
        
        if (playerUnitData.dataHealth.Health <= 0 && !isPlayerTowerDead)
        {
            AudioManager.Instance.AudioSource.Stop();
            AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.Lose,0.1f);
            Explosion.transform.position = new Vector2(X_PlayerCord,Ycord);
            Explosion.SetActive(true);
            PlayerTower.SetActive(false);
            isPlayerTowerDead = true;
        }
        else if(enemyUnitData.dataHealth.Health <= 0 && !isEnemyTowerDead)
        {
            AudioManager.Instance.AudioSource.Stop();
            AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.Win);
            Explosion.transform.position = new Vector2(X_EnemyCord, Ycord);
            Explosion.SetActive(true);
            EnemyTower.SetActive(false);
            isEnemyTowerDead = true;
        }
    }

    private void CheckTowerUpdate()
    {
        for (var i = 0; i < GameManager.Instance.towerUpdates.Count; i++)
        {
            if (i < SaveLoadManager.Instance.playerData.isPurchasedItem.Count && i == SaveLoadManager.Instance.playerData.isPurchasedItem[i])
                GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = true;
            else
                GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isPurchased = false;
        }

        for (var i = 0; i < GameManager.Instance.towerUpdates.Count; i++)
        {
            if (i < SaveLoadManager.Instance.playerData.isCurrentUnit.Length && i == SaveLoadManager.Instance.playerData.currentTowerUpdate)
            {
                GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = true;
                currentTowerUpdate = Instantiate(GameManager.Instance.towerUpdates[i], new Vector3(spotTowerUpdate.transform.position.x, spotTowerUpdate.transform.position.y, spotTowerUpdate.transform.position.z), Quaternion.identity);
            }
            else
            {
                GameManager.Instance.towerUpdates[i].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
                if(GameManager.Instance.towerUpdates[i] == currentTowerUpdate)
                    Destroy(currentTowerUpdate);
            }
        }
    }
}
