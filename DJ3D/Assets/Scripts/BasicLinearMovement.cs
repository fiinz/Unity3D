using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLinearMovement : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 targetPos;
    private Vector3 originalPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed = 30;
    public float aceleration;

    public bool acelerationMode=true;
    public bool decerationMode = true;   
    public float distanceBreak=1;

 


    // Start is called before the first frame update
    void Awake()
    {

        if (acelerationMode) speed = 0;
        if (decerationMode) speed = maxSpeed;

         originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 2) return;
     
        targetPos = targetObject.position;
        Vector3 dif = targetPos - transform.position;
        Vector3 dir = dif.normalized;
        float distance = dif.magnitude;
             
      
         if (acelerationMode) { speed += aceleration; if (speed > maxSpeed) speed = maxSpeed; }



         if (decerationMode && distance <= distanceBreak) { speed = maxSpeed * (distance / distanceBreak); }



         if (distance < 0.1f) { speed = 0; transform.position = targetPos; }



            
        if (targetPos != null)
        {
            transform.position += dir * speed * Time.deltaTime;
        }

    }
    private void OnDrawGizmos()
    {
        
        Vector3 dif = targetPos - transform.position;
        Vector3 dir = dif.normalized;
        float distance = dif.magnitude;
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + dir*3);


    }
}
