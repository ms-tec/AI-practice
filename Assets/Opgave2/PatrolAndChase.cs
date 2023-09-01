using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    [SerializeField] private float moveSpeed;

    private State state = State.PatrolState;
    private CharacterController controller;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetPosition = point1.position;
        targetPosition.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.PatrolState)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if ((targetPosition - transform.position).magnitude < moveSpeed * 0.1f)
        {
            (point1, point2) = (point2, point1);
            targetPosition = point1.position;
            targetPosition.y = transform.position.y;
        }
        transform.LookAt(targetPosition);
        controller.Move(moveSpeed * Time.deltaTime * transform.forward);
    }

    enum State
    {
        PatrolState,
        ChaseState
    }
}
