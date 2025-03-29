using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        /*GameObject EnemyClone = */Instantiate(enemy, new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10)), Quaternion.identity);
        /*GameObject EnemyClone2 = */Instantiate(enemy, new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10)), Quaternion.identity);
    }

    void Update()
    {
        //GameObject EnemyClone = Instantiate(enemy, new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10)), Quaternion.identity);
    }
}
