using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WalkTowards : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float oxDiference = target.position.x-transform.position.x;
        float oyDiference = target.position.z - transform.position.z;
        Vector3 diferenceTarget = target.position- transform.position;
        float distance = diferenceTarget.magnitude;

        transform.position += diferenceTarget.normalized*Time.deltaTime*(distance);

        
    }
}
