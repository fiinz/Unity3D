using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAngle : MonoBehaviour
{
    public GameObject target;
    public float ang;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dif = (target.transform.position - transform.position);
        ang = Mathf.Atan2(dif.x,dif.y)*Mathf.Rad2Deg;

        
    }
}
