using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyDamageManager;

public class Gun : MonoBehaviour
{
    public EnemyDamageManager enemyDamageManager;

    public ParticleSystem MuzzleFlash;

    public float damage = 10f;
    public float range = 100f;
    public float radius = 0.7f;

    [SerializeField]LayerMask Enemy;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = LayerMask.NameToLayer("Enemy");
        ray = new Ray(this.transform.position, transform.forward);            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();

        Debug.DrawRay(this.transform.position, transform.forward * 50, Color.red);
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        ray = new Ray(this.transform.position, transform.forward);
        if (Physics.SphereCast(ray, radius, out hit, range))
        {
            EnemyDamage enemyDamage;
            enemyDamage = hit.transform.GetComponentInParent<EnemyDamage>();
            if (enemyDamage != null)
            {
                Debug.Log("Попали во врага");
                enemyDamage.EnemyTakeDamage(damage, hit.transform.name);
            }
            //if (hit.transform.tag == "Enemy")
            //{
            //    Debug.Log("Попали во врага");
            //    enemyDamageManager.OnEnemyTakeDamage(damage, hit.collider.name);
            //}
        }
    }
}
