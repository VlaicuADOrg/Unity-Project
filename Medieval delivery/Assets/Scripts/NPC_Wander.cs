using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC_Wander : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public float wanderRadius = 15f;
    public float minWanderDistance = 6f;

    public float minWaitTime = 2f;
    public float maxWaitTime = 4f;

    float waitTimer;
    float currentWaitTime;
    bool isWaiting;
    bool hasStarted;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        if (!agent.isOnNavMesh)
        {
            enabled = false;
            return;
        }

        agent.stoppingDistance = 0.5f;
        agent.autoBraking = false;

        currentWaitTime = Random.Range(minWaitTime, maxWaitTime);

        Invoke(nameof(StartWander), Random.Range(0.2f, 1.2f));
    }

    void StartWander()
    {
        hasStarted = true;
        MoveToNewPoint();
    }

    void Update()
    {
        if (!hasStarted)
            return;

        animator.SetFloat(
            "Speed",
            agent.velocity.magnitude,
            0.1f,
            Time.deltaTime
        );

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                waitTimer = 0f;
            }

            waitTimer += Time.deltaTime;

            if (waitTimer >= currentWaitTime)
            {
                currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
                MoveToNewPoint();
                isWaiting = false;
            }
        }
    }

    void MoveToNewPoint()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, minWanderDistance);
        agent.SetDestination(newPos);
    }

    Vector3 RandomNavSphere(Vector3 origin, float maxDist, float minDist)
    {
        if (minDist >= maxDist)
            minDist = maxDist * 0.5f;

        for (int i = 0; i < 10; i++) // REDUS de la 30
        {
            Vector3 rand = Random.insideUnitSphere * maxDist;
            rand.y = 0;
            rand += origin;

            if (Vector3.Distance(origin, rand) < minDist)
                continue;

            if (NavMesh.SamplePosition(rand, out NavMeshHit hit, maxDist, NavMesh.AllAreas))
                return hit.position;
        }

        return origin;
    }
}
