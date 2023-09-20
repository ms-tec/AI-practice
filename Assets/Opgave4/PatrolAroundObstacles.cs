using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAroundObstacles : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    [SerializeField] private float moveSpeed;

    private Vector3 targetPosition;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPosition = point1.position;
        targetPosition.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void NextTarget()
    {
        (point1, point2) = (point2, point1);
        targetPosition = point1.position;
        targetPosition.y = transform.position.y;
    }

    void Patrol()
    {
        if (agent.remainingDistance < agent.radius)
        {
            NextTarget();
        }
        agent.SetDestination(targetPosition);
    }
}
