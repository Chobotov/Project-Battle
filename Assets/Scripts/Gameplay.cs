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

    [Header("Взрыв")]
    [SerializeField]
    private GameObject towerUpdate;

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

    void Start()
    {
        CheckTowerUpdate();
        isEnemyTowerDead = false;
        isPlayerTowerDead = false;
        playerUnitData = PlayerTower.GetComponent<UnitData>();
        enemyUnitData = EnemyTower.GetComponent<UnitData>();
    }

    void Update()
    {
        playerHealth = playerUnitData.dataHealth.Health;
        
        if (playerUnitData.dataHealth.Health <= 0)
        {
            Explosion.transform.position = new Vector2(X_PlayerCord,Ycord);
            Explosion.SetActive(true);
            PlayerTower.SetActive(false);
            isPlayerTowerDead = true;
        }
        else if(enemyUnitData.dataHealth.Health <= 0)
        {
            Explosion.transform.position = new Vector2(X_EnemyCord, Ycord);
            Explosion.SetActive(true);
            EnemyTower.SetActive(false);
            isEnemyTowerDead = true;
        }
    }

    private void CheckTowerUpdate()
    {
        if (towerUpdate.GetComponent<UnitData>().unitProperties.isCurrentUnit == true)
            towerUpdate.SetActive(true);
        else
            towerUpdate.SetActive(false);
    }
}
