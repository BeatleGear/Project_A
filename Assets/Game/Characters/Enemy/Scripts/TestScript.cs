using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyCount());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemyCount()
    {        
        yield return new WaitForSeconds(5);
        Debug.Log("Прошло 5 секунд");
    }
}
