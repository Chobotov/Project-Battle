﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Заклинание, которое вызывают юниты Маг
public class Fireball : MonoBehaviour
{
    public int speed;
    public int damage;
    private bool isHit;

    public GameObject currentEnemy;

    private float Distance
    {
        get
        {
            return Vector2.Distance(transform.position,currentEnemy.transform.position);
        }
    }
    private void Start()
    {
        isHit = true;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentEnemy.transform.position, Time.deltaTime * speed);
        if (Distance <= 0.05f && isHit)
        {
            isHit = false;
            AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.FireballAudio);
            currentEnemy.GetComponent<EnemyUnit>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (currentEnemy.gameObject == null)
        {
            Destroy(gameObject);
        }
    }
}
