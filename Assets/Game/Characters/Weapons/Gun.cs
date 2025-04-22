using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public EnemyDamageManager enemyDamageManager;

    public ParticleSystem MuzzleFlash;

    public float damage = 10f;
    public float range = 100f;
    public float radius = 0.7f;

    [SerializeField]LayerMask Enemy;
    [SerializeField, Range(1, 1000)] float _force; 

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
        if (EventSystem.current.IsPointerOverGameObject())
            return;

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
                Vector3 forceDirection = (hit.point - this.transform.position).normalized;
                enemyDamage.EnemyTakeDamage(damage, hit.transform.name, forceDirection * _force, hit.point);
            }
        }
    }
}
