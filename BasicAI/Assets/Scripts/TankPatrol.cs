using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrol : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private Ray2D ray;
    private RaycastHit2D hit;
    private float maxDistanceToCheck = 6.0f;
    private float currentDistance;
    private Vector3 checkDirection;

    // transform points set on the scene
    public Transform pointA;
    public Transform pointB;

    private int currentTarget;
    private float distanceFromTarget;
    private Transform[] patrolPoints = null;


    private void Awake()
    {
        //this will 
        animator = gameObject.GetComponent<Animator>();
        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;

        patrolPoints = new Transform[2] {
            pointA,
            pointB
        };
        currentTarget = 0;


    }
   

    // Update is called once per frame
    void Update()
    {
         Move();

        distanceFromTarget = Vector3.Distance(patrolPoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
    }

    /// <summary>
    /// Moves the tank towards the target
    /// </summary>
    public void Move()
    {
        var dir = patrolPoints[currentTarget].position - transform.position; // gets the direction to target
        transform.position += dir.normalized * Time.deltaTime * 1.0f; // moves the tank in the calculated distance
        transform.up = dir.normalized; //orients or rotates the tank to the direction


    }

    /// <summary>
    /// Togles the next Target between p1 and p2
    /// this is called by the State Behaviors on Animator
    /// </summary>
    public void SetNextPoint()
    { 
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;
        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,checkDirection*maxDistanceToCheck);

    }
}
