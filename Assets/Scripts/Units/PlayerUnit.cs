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
        health = GetComponent<DataHealth>().health;
        isDead = GetComponent<DataHealth>().isDead;
    }

    public void TakeDamage(float damage)
    {
        GetComponent<DataHealth>().health -= damage;
        if (GetComponent<DataHealth>().health > 0)
        {
            HealthSlider.value = GetComponent<DataHealth>().health;
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
