using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExample : MonoBehaviour
{
    private LineRenderer _lr;

    public float range;
    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast (transform.position, transform.forward, out hit, range))
        {
            if (hit.collider)
                _lr.SetPosition(1 , new Vector3(0, 0, hit.distance));
        }
        else
            _lr.SetPosition(1 , new Vector3(0, 0, range));
    }
}
