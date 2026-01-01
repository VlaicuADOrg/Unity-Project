using UnityEngine;
using UnityEngine.AI;

public class NPC_Wander : MonoBehaviour
{
    [Header("Movement")]
    public float wanderRadius = 12f;      // mai mare = merge mai mult
    public float stoppingDistance = 0.6f;

    [Header("Idle")]
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;

    private NavMeshAgent agent;
    private Animator anim;
    private float idleTimer;
    private float currentIdleTime;
    private bool isWaiting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        agent.stoppingDistance = stoppingDistance;
        agent.autoBraking = false; // 🔥 foarte important

        PickNewIdleTime();
        MoveToNewPoint();
    }

    void Update()
    {
        // Animatie lina (fara sacadare)
        anim.SetFloat("Speed", agent.velocity.magnitude, 0.1f, Time.deltaTime);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                idleTimer = 0f;
            }

            idleTimer += Time.deltaTime;

            if (idleTimer >= currentIdleTime)
            {
                PickNewIdleTime();
                MoveToNewPoint();
                isWaiting = false;
            }
        }
    }

    void MoveToNewPoint()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
        agent.SetDestination(newPos);
    }

    void PickNewIdleTime()
    {
        currentIdleTime = Random.Range(minIdleTime, maxIdleTime);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 rand = Random.insideUnitSphere * dist;
        rand.y = 0;
        rand += origin;

        NavMesh.SamplePosition(rand, out NavMeshHit hit, dist, NavMesh.AllAreas);
        return hit.position;
    }
}
