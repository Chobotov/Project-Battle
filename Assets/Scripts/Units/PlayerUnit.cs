using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnit : MonoBehaviour
{
    public Slider HealthSlider;
    private float health;
    private bool isDead;

    private void Start()
    {
        health = GetComponent<UnitData>()._dataHealth.health;
        isDead = GetComponent<UnitData>()._dataHealth.isDead;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            HealthSlider.value = health;
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
