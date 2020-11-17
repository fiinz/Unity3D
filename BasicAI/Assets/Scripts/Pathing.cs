using UnityEngine;
using System.Collections;

public class Pathing : MonoBehaviour
{
    [SerializeField] private Path path; //the current path, can be drag and dropped in inspector
    [SerializeField] float speed; // tank max speed
    [SerializeField] float mass = 10.0f;// affects the way the car rotates
    [SerializeField] bool isLooping = true; //loop mode
    private float speedByFrame; //the current speed affected by delta time
    private int currentPathIndex; //em que index é que se encontra
    private Vector3 direction; //current tank direction
    private Vector3 targetPoint; //the target point
    private Vector3 targetDirection; // target waypoint direction

    // Use this for initialization
    void Start()
    {
        //verificar em 2D se é o up ou o forward
        direction = transform.up; // pois acho que esta parte é importante para iniciar qual a direção que o tank se sencontra.
        targetPoint = path.GetPoint(currentPathIndex);

    }
    
    private bool TargetReached()
    {
        /// checks if the target was reached 
        //o radius is the tolerance regarding the distance
        return (Vector3.Distance(transform.position, targetPoint) < path.radius);

    }
    ///Sets the  Target to the next waypoint
    private bool SetNextTarget()
    {
        bool success = false;
        
        if (currentPathIndex < path.PathLength-1)  // if the path was not completed
        {
            //passa para o seguinte
            currentPathIndex++;
            success = true;

        }
        else
        { // if end reached
            if (isLooping)
            {
                //goes back to 0 if loop mode
                currentPathIndex = 0;
                success = true;
            }
            else
            {
                success = false; // no more waypoints
            }

        }
        // a new target point is assigned 
        targetPoint = path.GetPoint(currentPathIndex);

        return success;
    }
    Vector3 Steer(Vector3 target)
    {
        targetDirection = (target - transform.position).normalized;
        targetDirection *= speedByFrame; 

        Vector3 steeringForce = targetDirection - direction; //the difference between my current dir and my target dir
        Vector3 acelleration = steeringForce / mass; //affecting the speed of steering,
        return acelleration;
    }
    // Update is called once per frame
    void Update()
    {
        if (path == null) { return; } 
        speedByFrame = speed * Time.deltaTime; //current speed keeps a reference of the speed by Frame
        if (TargetReached())
        {
            // no target will return
            if (!SetNextTarget()) { return; }
        }

        direction = Steer(targetPoint);
        transform.position += direction; //ele vai na direção que foi definida ( inicialmente forward)
        transform.up = new Vector3(direction.x, direction.y, 0);
    }
}

