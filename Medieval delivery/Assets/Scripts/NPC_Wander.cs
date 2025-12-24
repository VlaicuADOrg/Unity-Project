using UnityEngine;
using UnityEngine.AI;

public class NPC_Wander : MonoBehaviour
{
    public float wanderRadius = 5f;
    public float idleTime = 2f;

    private NavMeshAgent agent;
    private Animator anim;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        timer = idleTime;
    }

    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);

        timer += Time.deltaTime;

        if (!agent.pathPending && agent.remainingDistance <= 0.3f)
        {
            if (timer >= idleTime)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 rand = Random.insideUnitSphere * dist;
        rand += origin;
        NavMesh.SamplePosition(rand, out NavMeshHit hit, dist, NavMesh.AllAreas);
        return hit.position;
    }
}
