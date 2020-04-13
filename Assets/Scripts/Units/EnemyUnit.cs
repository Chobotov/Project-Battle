using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    public Slider healthSlider;
    private float health;
    private bool isDead;
    UnitLinks unitLinks;
    private void Start()
    {
        unitLinks = GetComponent<UnitLinks>();
        health = unitLinks.unitData.dataHealth.health;
        isDead = unitLinks.unitData.dataHealth.isDead;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            healthSlider.value = health;
        }
        else
        {
            isDead = true;
        }
        
        if (isDead)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
