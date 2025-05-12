using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float _health = 50;

    [SerializeField] Enemy _enemy;
    [SerializeField] EnemyBeh _enemyBeh;
    [SerializeField] CapsuleCollider _capsuleCollider;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] RagdollHandler _ragdollHandler;

    public EnemyDamageManager enemyDamageManager;

    private void Start()
    {
        enemyDamageManager = GameObject.Find("Directional Light").GetComponent<EnemyDamageManager>();
    }
    public void EnemyTakeDamage(float damage, string name, Vector3 force, Vector3 hitPoint)
    {
        Debug.Log(this.gameObject.name);
        Debug.Log(name);

        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0)
        {
            Die();
            _ragdollHandler.Hit(force, hitPoint);
        }
    }

    void Die()
    {
        _capsuleCollider.enabled = false;
        _enemyBeh.enabled = false;
        _agent.enabled = false;
        _enemy.Kill();        
        //enemyDamageManager.enemyTakeDamage -= OnEnemyTakeDamage;
        //Destroy(gameObject, 0.5f);        
    }
}
