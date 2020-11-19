using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(-5f, 5f)]
    [SerializeField]private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position+=new Vector3(speed*Time.deltaTime, 0,0);
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        //transform.position += Vector3.right * 0.1f;

    }
}
