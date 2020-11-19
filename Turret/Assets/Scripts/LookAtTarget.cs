using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    private Vector3 difBetweenTarget;
    private Vector3 dirToTarget;
    private float distToTarget;
    public float dotProd;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, difBetweenTarget);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, dirToTarget);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);

        


    }

    // Update is called once per frame
    void Update()
    {
        difBetweenTarget = target.position - transform.position;
        dirToTarget = difBetweenTarget.normalized;
        distToTarget = difBetweenTarget.magnitude;
        dotProd = Vector3.Dot(transform.forward, target.forward);

        
    }
}
