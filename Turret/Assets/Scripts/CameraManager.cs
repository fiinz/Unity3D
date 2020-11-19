using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float distToTarget;
    [Range(2,5)]
    public float minDistance;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 difToTarget = target.position - transform.position;//diferenca
        Vector3 dirToTarget = difToTarget.normalized; //direcao        
        distToTarget = difToTarget.magnitude;
        transform.forward = dirToTarget;


        
    }
}
