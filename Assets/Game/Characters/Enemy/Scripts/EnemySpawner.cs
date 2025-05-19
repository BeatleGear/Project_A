using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int _numberOfCloneEnemy;
    [SerializeField] int _valueOfRange;
    void Start()
    {
        string _enemyName = "ZombieClone";
        for (int i = 0; i < _numberOfCloneEnemy; i++) 
        {
            GameObject EnemyClone = Instantiate(enemy, new Vector3(Random.Range(-_valueOfRange, _valueOfRange) + 
                transform.position.x, 0.0f, Random.Range(-_valueOfRange, _valueOfRange) + transform.position.z), Quaternion.identity) as GameObject;

            EnemyClone.name = _enemyName + (i+1).ToString();
        }
    }

    void Update()
    {

    }
}
