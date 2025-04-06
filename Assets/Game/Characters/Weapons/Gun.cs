using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public EnemyEventController enemyEventController;

    public float damage = 10f;
    public float range = 100f;
    public float radius = 0.5f;

    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(this.transform.position, transform.forward);            
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
        RaycastHit hit;
        ray = new Ray(this.transform.position, transform.forward);
        if(Physics.SphereCast(ray, radius, out hit, range))
        {
            Debug.Log("куда-то попали");
            if(hit.transform.tag == "Enemy")
            {
                Debug.Log("Попали во врага");
                enemyEventController.OnEnemyTakeDamage(damage);
            }
        }
        Debug.DrawRay(this.transform.position, transform.forward * 50, Color.red);
    }
    void Shoot()
    {

    }
}
