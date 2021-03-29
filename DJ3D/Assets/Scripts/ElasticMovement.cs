using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticMovement : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 targetPos;

    [SerializeField]
    private float aceleration=1;
    [SerializeField]
    private float maxSpeed = 10;
    private float frameAceleration;
    private Vector3 inertia;    
    public bool elasticMode = true;
    private Vector3 oldDir;


    // Start is called before the first frame update
    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        frameAceleration = aceleration * Time.deltaTime;
        targetPos = targetObject.position;
        Vector3 difToTarget = targetPos - transform.position;
        Vector3 targetDir = difToTarget.normalized;       
        float distance = difToTarget.magnitude;

        if (targetPos!= null)
        {
            inertia=inertia+(targetDir* frameAceleration);
            if (inertia.magnitude > maxSpeed) inertia = inertia.normalized * maxSpeed;
            transform.position += inertia;
        }

        if (Vector3.Dot(oldDir,targetDir)<1)
        {
            inertia = inertia.normalized * inertia.magnitude * 0.99f;

        }
        if (distance < 0.05f && inertia.magnitude < 0.01f) { inertia = Vector3.zero; transform.position = targetPos; }

        oldDir = new Vector3(targetDir.x, targetDir.y, targetDir.y);


    }
    private void OnDrawGizmos()
    {
        
        Vector3 dif = targetPos - transform.position;
        Vector3 dir = dif.normalized;
        float distance = dif.magnitude;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + inertia*20);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position+ transform.forward);


    }
}
