using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        string _enemyName = "ZombieClone";
        for (int i = 0; i < 10; i++) 
        {
            GameObject EnemyClone = Instantiate(enemy, new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10)), Quaternion.identity) as GameObject;
            EnemyClone.name = _enemyName + (i+1).ToString();
        }
    }

    void Update()
    {

    }
}
