using UnityEngine;
using UnityEngine.AI;

public class EnemyBeh : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public EnemyEventController enemyEventController;

    public LayerMask whatIsGround, whatIsPlayer;

    bool isEnemyIdle;

    float idleTime;
    float idleTimeToIdle = 3;

    public Vector3 distanceToWalkPoint;
    public Vector3 currentWalkPoint;
    public int EnemyOnState;
    public float EnemyDistanceToPoint;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;

    //States
    public float sightRange, attackRange, attackDistance;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pistol Idle").GetComponent<Transform>();
        isEnemyIdle = true;
        idleTime = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    private void Patrolling()
    {
        if (isEnemyIdle)
        {
            enemyEventController.OnEnemyAnimations("Idle");

            agent.SetDestination(transform.position);
            idleTime -= Time.deltaTime;
            if (idleTime < 0)
            {
                isEnemyIdle = false;
                idleTime = idleTimeToIdle;
            }
        }
        else 
        {
            enemyEventController.OnEnemyAnimations("Patrolling");

            if (!walkPointSet)
                SearchWalkPoint();
            if (walkPointSet)
                agent.SetDestination(walkPoint);

            currentWalkPoint = distanceToWalkPoint;

            distanceToWalkPoint = transform.position - walkPoint;

            NewRoute();

            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
                isEnemyIdle = true;
                EnemyOnState = 0;
            }                
        }
    }
    void NewRoute()
    {
        if (((currentWalkPoint - distanceToWalkPoint).magnitude) < 0.001)
            EnemyOnState++;
        if (EnemyOnState > 20)
        {
            walkPointSet = false;
            isEnemyIdle = true;
            EnemyOnState = 0;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        enemyEventController.OnEnemyAnimations("Patrolling");
    }

    private void AttackPlayer()
    {
        if ((player.position - transform.position).magnitude < attackDistance)
        {
            Debug.Log("Должен атаковать");
            enemyEventController.OnEnemyAnimations("AttackPlayer");
            agent.SetDestination(transform.position);
        }
        transform.LookAt(player);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
