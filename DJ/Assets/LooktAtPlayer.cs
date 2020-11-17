using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooktAtPlayer : MonoBehaviour
{
    public Transform target;
    private Transform head;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var dif = target.position - transform.position;
        var dist = dif.magnitude;
        var dir = dif.normalized;
        
        var targeDir = new Vector3(dir.x, head.transform.forward.y, dir.z);
        
        //transform.forward=Vector3.Slerp(head.transform.forward, targeDir, Time.deltaTime*5);
        
        float ang= Vector3.Angle(head.transform.forward, targeDir);
        Debug.Log(ang);
        Quaternion targetRotation = Quaternion.LookRotation(targeDir);
        head.transform.rotation = Quaternion.Slerp(head.transform.rotation, targetRotation, 5 * Time.deltaTime);

    }
}
