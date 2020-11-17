using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform target;
    private Vector3 difBetweenTarget;
    private Vector3 dirToTarget;
    private float distToTarget;
    public Light light;
    public float maxItensity = 2;
    public float distanceThreshold = 5;

    // Start is called before the first frame update
    void Start()
    { }

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
        
        if (distToTarget <= distanceThreshold)
        {
            float distanceRatio = distToTarget / distanceThreshold;
            float lightItensity = (1-distanceRatio) * maxItensity;
            light.intensity = lightItensity;

        }
    }
}
