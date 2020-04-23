using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    public Slider healthBar;
    private UnitData unitData;
    private void Start()
    {
        unitData = GetComponent<UnitData>();
        if (healthBar != null)
            healthBar.value = unitData.dataHealth.Health;
        unitData.unitProperties.state = State.Idle;
    }


    public void TakeDamage(int damage)
    {
        unitData.dataHealth.Health -= damage;
        if (unitData.dataHealth.Health > 0)
        {
            healthBar.value = unitData.dataHealth.Health;
        }
        else
        {
            healthBar.value = 0;
            Die();
        }
    }

    private void Die()
    {
        //if (GamePlay.Instance.playerCount > 0) GamePlay.Instance.playerCount--;
        unitData.unitProperties.state = State.Dead;
    }

    private void DestroyUnit()
    {
        Destroy(gameObject);
    }
}
