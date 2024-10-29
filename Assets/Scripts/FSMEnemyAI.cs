using UnityEngine;
using UnityEngine.AI;  // For NavMeshAgent

public class FSMEnemyAI : MonoBehaviour
{
    public enum State { Idle, Chase, Attack }
    public State currentState = State.Idle;

    public float visionRange;
    public float attackRange = 9f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;

    public int aiIndex;
    public int patrolCounter;
    public bool patrolForward;
    public int patrolRange;
    public float speed;

    private NavMeshAgent agent;
    private GameObject baseObject;
    private bool canAttack = true;

    void Start()
    {
        this.aiIndex = Random.Range(0, 3);
        this.patrolCounter = 0;
        this.patrolForward = true;
        this.patrolRange = Random.Range(2, 9) * 10;
        this.speed = Random.Range(5, 10);
        this.visionRange = 10000;

        agent = GetComponent<NavMeshAgent>();
        baseObject = GameObject.FindGameObjectWithTag("Base");
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Patrol();
                LookForBase();
                break;

            case State.Chase:
                ChaseBase();
                break;

            case State.Attack:
                AttackBase();
                break;
        }
    }

    void Patrol()
    {
        if (this.aiIndex == 0) // circle
        {
            transform.Rotate(0, this.patrolRange * 3f * Time.deltaTime, 0);
            transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime * 0.3f);
        }
        else if (this.aiIndex == 1) // back forth
        {
            if (patrolCounter > patrolRange)
            {
                patrolForward = false;
            }
            if (patrolCounter < 0)
            {
                patrolForward = true;
            }

            if (patrolForward)
            {
                transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime * 0.3f);
                patrolCounter++;
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, -speed * Time.deltaTime * 0.3f);
                patrolCounter--;
            }
        }
        else // left right
        {
            if (patrolCounter > patrolRange)
            {
                patrolForward = false;
            }
            if (patrolCounter < 0)
            {
                patrolForward = true;
            }

            if (patrolForward)
            {
                transform.Translate(speed * Time.deltaTime * 0.3f, 0, speed * Time.deltaTime);
                patrolCounter++;
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime * 0.3f, 0, -speed * Time.deltaTime);
                patrolCounter--;
            }
        }
    }

    void LookForBase()
    {
        float distanceToBase = Vector3.Distance(transform.position, baseObject.transform.position);
        if (distanceToBase <= visionRange)
        {
            currentState = State.Chase;
        }
    }

    void ChaseBase()
    {
        agent.SetDestination(baseObject.transform.position);

        float distanceToBase = Vector3.Distance(transform.position, baseObject.transform.position);
        if (distanceToBase <= attackRange)
        {
            currentState = State.Attack;
            Debug.Log("?????");
        }
        else if (distanceToBase > visionRange)
        {
            currentState = State.Idle;
        }
    }

    void AttackBase()
    {
        agent.SetDestination(transform.position); // stop moving

        float distanceToBase = Vector3.Distance(transform.position, baseObject.transform.position);
        if (distanceToBase > attackRange)
        {
            currentState = State.Chase;
            return;
        }

        if (canAttack)
        {
            StartCoroutine(AttackCooldown());
        }
    }

    System.Collections.IEnumerator AttackCooldown()
    {
        Debug.Log("Based HP");
        canAttack = false;
        baseObject.GetComponent<BaseHealth>().TakeDamage(attackDamage);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
