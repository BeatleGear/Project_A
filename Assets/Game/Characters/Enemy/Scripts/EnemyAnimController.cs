using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public EnemyEventController enemyEventController;

    private void Start()
    {
        enemyEventController.enemyAnimations += OnEnemyAnimations;
    }
    private void OnEnemyAnimations(string pos)
    {
        switch (pos)
        {
            case "Idle":
                _animator.SetBool("toWalk", false);
                _animator.SetBool("toAttack", false);
                _animator.SetBool("toIdle", true);
                break;

            case "Patrolling":                
                _animator.SetBool("toAttack", false);
                _animator.SetBool("toIdle", false);
                _animator.SetBool("toWalk", true);
                break;

            case "AttackPlayer":
                _animator.SetBool("toWalk", false);
                _animator.SetBool("toIdle", false);
                _animator.SetBool("toAttack", true);                
                break;

            default:
                break;
        }
    }
}
