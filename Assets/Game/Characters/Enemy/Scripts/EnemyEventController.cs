using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventController : MonoBehaviour
{
    public delegate void EnemyAnimations(AnimationType animationType);
    public static event EnemyAnimations enemyAnimations;

    public static void OnEnemyAnimations(AnimationType Type)
    {
        enemyAnimations?.Invoke(Type);
    }
    public enum AnimationType
    {
        Idle,
        Patrolling,
        ChasePlayer,
        AttackPlayer
    }
}
