using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstExample : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] EnemyBeh _enemyBeh;
    [SerializeField] CapsuleCollider _capsuleCollider;
    [SerializeField] NavMeshAgent _agent;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            _capsuleCollider.enabled = false;
            _enemyBeh.enabled = false;
            _agent.enabled = false;
            _enemy.Kill();            
        }
    }
}
