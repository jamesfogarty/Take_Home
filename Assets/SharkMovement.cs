using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SharkMovement : MonoBehaviour
{
    //public Transform[] points;
    //private int destPoint = 0;
    //private NavMeshAgent agent;


    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();

    //    // Disabling auto-braking allows for continuous movement
    //    // between points (ie, the agent doesn't slow down as it
    //    // approaches a destination point).
    //    agent.autoBraking = false;

    //    GotoNextPoint();
    //}


    //void GotoNextPoint()
    //{
    //    // Returns if no points have been set up
    //    if (points.Length == 0)
    //        return;

    //    // Set the agent to go to the currently selected destination.
    //    agent.destination = points[destPoint].position;

    //    // Choose the next point in the array as the destination,
    //    // cycling to the start if necessary.
    //    destPoint = (destPoint + 1) % points.Length;
    //}


    //void Update()
    //{
    //    // Choose the next destination point when the agent gets
    //    // close to the current one.
    //    if (!agent.pathPending && agent.remainingDistance < 0.5f)
    //        GotoNextPoint();
    //}
    public Transform[] target;
    Transform newTarget;

    Animator bassAnimation;

    bool isMoving = false;

    public float speed = 2.0f;

    public bool predator = false;

    void Update()
    {
        if (isMoving == false)
        {
            newTarget = target[Random.Range(0, target.Length)];
            isMoving = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, newTarget.position, speed * Time.deltaTime);

        if (transform.position == newTarget.position)
        {
            isMoving = false;
        }

        transform.LookAt(newTarget);
    }
}
