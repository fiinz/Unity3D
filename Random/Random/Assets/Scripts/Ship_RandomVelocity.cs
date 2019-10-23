using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_RandomVelocity : MonoBehaviour
{
    private float vx;
    private float vy;

    // Start is called before the first frame update
    void Start()
    {
        vx = Random.Range(-10, 10); //random velcocity X
        vy = Random.Range(-10, 10); //random velcocity Y

    }

    // Update is called once per frame
    void Update()
    {
        //time.deltatime compensa o framerate das maquinas
        transform.position += new Vector3(vx* Time.deltaTime, vy*Time.deltaTime, 0);
        
    }
}
