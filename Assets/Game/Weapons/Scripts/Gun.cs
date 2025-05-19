using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public EnemyDamageManager enemyDamageManager;

    public ParticleSystem MuzzleFlash;

    [SerializeField]

    public float damage = 10f;
    public float range;
    public float radius = 0.01f;

    [SerializeField] LayerMask Enemy;
    [SerializeField, Range(1, 1000)] float _force;
    [SerializeField] private bool _isAutomaticShooting;
    [SerializeField] private float _fireRate = 15;
    [SerializeField] private GameObject _player;

    private float _nextTimeToFire = 0;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = LayerMask.NameToLayer("Enemy");
        ray = new Ray(transform.position, _player.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(_isAutomaticShooting)
        {
            if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / _fireRate;
                Shoot();
            }
        }
        else 
        {
            if (Input.GetButtonDown("Fire1"))
                Shoot();
        }
        Debug.DrawRay(transform.position, _player.transform.forward * range, Color.red);
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        ray = new Ray(transform.position, _player.transform.forward);
        if (Physics.SphereCast(ray, radius, out hit, range))
        //if (Physics.Raycast(ray, out hit, range))
        {
            EnemyDamage enemyDamage;
            enemyDamage = hit.transform.GetComponentInParent<EnemyDamage>();
            if (enemyDamage != null)
            {
                Debug.Log("Попали во врага");
                Vector3 forceDirection = (hit.point - _player.transform.position).normalized;
                enemyDamage.EnemyTakeDamage(damage, hit.transform.name, forceDirection * _force, hit.point);
            }
        }
    }
}
