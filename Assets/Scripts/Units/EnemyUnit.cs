using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    public Slider healthSlider;
    UnitLinks unitLinks;
    private void Start()
    {
        unitLinks = GetComponent<UnitLinks>();
        GetComponent<SpriteRenderer>().sprite = unitLinks.unitData.unit.sprite;
    }

    public void TakeDamage(int damage)
    {
        unitLinks.unitData.unit.dataHealth.health -= damage;
        if (unitLinks.unitData.unit.dataHealth.health > 0)
        {
            healthSlider.value = unitLinks.unitData.unit.dataHealth.health;
        }
        else
        {
            unitLinks.unitData.unit.dataHealth.isDead = true;
        }
        
        if (unitLinks.unitData.unit.dataHealth.isDead)
        {
            Die();
        }
    }

    void Die()
    {
        if(GamePlay.Instance.enemyCount > 0) GamePlay.Instance.enemyCount--;
        Destroy(gameObject);
    }
}
