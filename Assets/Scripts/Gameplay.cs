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

    private UnitData playerUnitData,
                     enemyUnitData;

    [Header("X-координата взрыва")]
    [SerializeField]
    private float X_PlayerCord,
                  X_EnemyCord;
    private float Ycord = 5f;
    void Start()
    {
        playerUnitData = PlayerTower.GetComponent<UnitData>();
        enemyUnitData = EnemyTower.GetComponent<UnitData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerUnitData.dataHealth.Health <= 0)
        {
            Explosion.transform.position = new Vector2(X_PlayerCord,Ycord);
            Explosion.SetActive(true);
            PlayerTower.SetActive(false);
        }
        else if(enemyUnitData.dataHealth.Health <= 0)
        {
            Explosion.transform.position = new Vector2(X_EnemyCord, Ycord);
            Explosion.SetActive(true);
            EnemyTower.SetActive(false);
        }
    }
}
