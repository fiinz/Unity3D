using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_RandomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Random.Range(-10,10), Random.Range(-10, 10), 0);


    }
}
