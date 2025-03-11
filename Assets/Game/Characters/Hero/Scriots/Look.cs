using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Look : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    float _minimumDistance = 0.2f;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        Debug.Log(hit.point);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Plane")
            {
                Vector3 toPoint = hit.point - Player.transform.position;
                if (toPoint.magnitude > _minimumDistance)
                {
                    float rotZ = Mathf.Atan2(toPoint.x, toPoint.z) * Mathf.Rad2Deg;
                    Player.transform.rotation = Quaternion.Euler(0f, rotZ, 0f);
                    Debug.Log(toPoint.magnitude);
                }

            }
        }       
    }
}
