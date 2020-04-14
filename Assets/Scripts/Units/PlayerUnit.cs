using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnit : MonoBehaviour
{
    public Slider healthSlider;

    UnitLinks unitLinks;
    private void Start()
    {
        unitLinks = GetComponent<UnitLinks>();
        unitLinks.unitData.dataHealth.health = 100;
        unitLinks.unitData.dataHealth.isDead = false;
    }

    public void TakeDamage(float damage)
    {
        unitLinks.unitData.dataHealth.health -= damage;
        if (unitLinks.unitData.dataHealth.health > 0)
        {
            healthSlider.value = unitLinks.unitData.dataHealth.health;
        }
        else
        {
            unitLinks.unitData.dataHealth.isDead = true;
        }

        if (unitLinks.unitData.dataHealth.isDead)
        {
            Die();
        }
    }

    void Die()
    {
        if (GamePlay.Instance.playerCount > 0) GamePlay.Instance.playerCount--;
        Destroy(gameObject);
    }
}
