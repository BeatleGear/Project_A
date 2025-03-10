using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Look : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 toPoint = hit.point - Player.transform.position;
            Player.transform.rotation = Quaternion.LookRotation(toPoint);
            Debug.Log(hit.point);
        }
       
    }
}
