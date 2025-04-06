using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyEventController enemyEventController;

    [SerializeField]
    float _health = 50;

    private void Start()
    {
        enemyEventController.enemyTakeDamage += OnEnemyTakeDamage;
    }

    void OnEnemyTakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(damage);
        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
