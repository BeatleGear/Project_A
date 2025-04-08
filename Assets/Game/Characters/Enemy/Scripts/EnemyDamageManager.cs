using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    public delegate void EnemyTakeDamage(float damage, string name);
    public event EnemyTakeDamage enemyTakeDamage;

    public void OnEnemyTakeDamage(float damage, string name)
    {
        enemyTakeDamage?.Invoke(damage, name);
    }
}
