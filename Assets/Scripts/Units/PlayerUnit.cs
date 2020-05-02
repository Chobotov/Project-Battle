using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnit : MonoBehaviour
{
    public Slider healthBar;
    private UnitData unitData;
    [SerializeField]
    private float volumeScale = 0.5f;

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
        unitData.unitProperties.state = State.Dead;
    }

    //Вызывается через анимацию смерти
    private void DeathScream()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.Death,volumeScale);
    }
    //Вызывается через анимацию смерти
    private void DestroyUnit()
    {
        LevelUIController.IntCountUnits -= 1;
        Destroy(gameObject);
    }
}
