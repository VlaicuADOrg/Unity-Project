using UnityEngine;

public class LiftPlatform : MonoBehaviour
{
    [SerializeField] private Transform topPoint;   
    [SerializeField] private float speed = 2f;
    [SerializeField] private float arriveEpsilon = 0.02f;

    private Vector3 bottomPos;
    private Vector3 topPos;

    private bool movingUp;
    private bool movingDown;

    private void Awake()
    {
        bottomPos = transform.position;
        topPos = topPoint.position;
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, topPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, topPos) <= arriveEpsilon)
            {
                transform.position = topPos;
                movingUp = false;
            }
        }
        else if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, bottomPos) <= arriveEpsilon)
            {
                transform.position = bottomPos;
                movingDown = false;
            }
        }
    }

    public void GoUp()
    {
        movingDown = false;
        movingUp = true;
    }

    public void GoDown()
    {
        movingUp = false;
        movingDown = true;
    }
}
