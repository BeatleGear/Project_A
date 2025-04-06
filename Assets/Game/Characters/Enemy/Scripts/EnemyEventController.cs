using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventController : MonoBehaviour
{
    public delegate void EnemyAnimations(string pos);
    public event EnemyAnimations enemyAnimations;

    public delegate void EnemyTakeDamage(float damage);
    public event EnemyTakeDamage enemyTakeDamage;

    public void OnEnemyAnimations(string pos)
    {
        enemyAnimations?.Invoke(pos);
    }

    public void OnEnemyTakeDamage(float damage)
    {
        Debug.Log("перед обработкой события урона");
        enemyTakeDamage?.Invoke(damage);
        Debug.Log("после обработки события урона");
    }
}
