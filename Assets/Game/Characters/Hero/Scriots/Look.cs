using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Look : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    LayerMask Cube;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    float delta;

    void Start()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Plane")
            {
                Vector3 toPoint = hit.point - Player.transform.position;
                float rotZ = Mathf.Atan2(toPoint.x, toPoint.z) * Mathf.Rad2Deg;
                Player.transform.rotation = Quaternion.Euler(0f, rotZ - delta, 0f);
                Debug.Log(hit.point);
            }
        }       
    }
}
