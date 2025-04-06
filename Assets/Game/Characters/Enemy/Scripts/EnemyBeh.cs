using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBeh : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public EnemyEventController enemyEventController;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    bool isEnemyIdle;

    float idleTime;
    float idleTimeToIdle = 3;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        //enemyEventController = GameObject.Find("EnemyEvent").GetComponent<EnemyEventController>();
        player = GameObject.Find("Pistol Idle").GetComponent<Transform>();
        isEnemyIdle = true;
        idleTime = idleTimeToIdle;
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
        //Debug.Log("Патруль");
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
            Vector3 distanceToWalkPoint = transform.position - walkPoint;
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
                isEnemyIdle = true;
            }                
        }
    }
    private void SearchWalkPoint()
    {
        //Debug.Log("Ищет точку");
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        //Debug.Log("Преследование");
        agent.SetDestination(player.position);
        enemyEventController.OnEnemyAnimations("Patrolling");
    }

    private void AttackPlayer()
    {
        //Debug.Log("Атака");
        if((player.position - transform.position).magnitude < 1)
        {
            enemyEventController.OnEnemyAnimations("AttackPlayer");
            agent.SetDestination(transform.position);
        }


        transform.LookAt(player);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
