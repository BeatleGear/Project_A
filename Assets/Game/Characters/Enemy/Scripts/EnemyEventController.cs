using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventController : MonoBehaviour
{
    public delegate void EnemyAnimations(string pos);
    public event EnemyAnimations enemyAnimations;

    public void OnEnemyAnimations(string pos)
    {
        enemyAnimations?.Invoke(pos);
    }
}
