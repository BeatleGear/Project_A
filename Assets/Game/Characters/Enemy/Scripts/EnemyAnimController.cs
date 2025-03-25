using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyEventController;

public class EnemyAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        EnemyEventController.enemyAnimations += OnEnemyAnimations;
    }
    private void OnEnemyAnimations(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Idle:        
                _animator.SetBool("toWalk", false);
                break;

            case AnimationType.Patrolling:  
                _animator.SetBool("toWalk", true);
                break;

            default:
                break;
        }
    }
}
