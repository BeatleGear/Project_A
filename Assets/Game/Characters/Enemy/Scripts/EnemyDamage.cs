using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float _health = 50;

    public EnemyDamageManager enemyDamageManager;

    private void Start()
    {
        enemyDamageManager = GameObject.Find("Directional Light").GetComponent<EnemyDamageManager>();
        enemyDamageManager.enemyTakeDamage += OnEnemyTakeDamage;
    }

    public void OnEnemyTakeDamage(float damage, string name)
    {
        if (this.gameObject.name == name)
        {
            _health -= damage;
            Debug.Log(_health);
            if (_health <= 0)
            {
                Die();
            }
        }

    }

    void Die()
    {
        enemyDamageManager.enemyTakeDamage -= OnEnemyTakeDamage;
        Destroy(gameObject, 0.5f);        
    }
}
