using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveJump : MonoBehaviour
{
    public GameObject objectTrail;
    public AnimationCurve lerpCurve;
    private float lerpRatio;
    public float lerpDuration;
    public float speed = 1.0f;
    public float height = 1;
    public bool trailMode = false;
    public int numberObjects;
    private GameObject[] objects;
    private float[] objectTimers;
    public float trailDelay;
    public float timer;
    public float next;
    private int numObjectsOnline = 0;
    // Start is called before the first frame update
    void Awake()
    {
        objects = new GameObject[numberObjects];
        objectTimers = new float[numberObjects];
        float alphaSteps = 1.0f / (numberObjects + 1.0f);
        next = Time.time + trailDelay+1;
        if (trailMode)
        {
            for (int i = 0; i < objects.Length; i++)
            {

                objects[i] = Instantiate(objectTrail);
                Color c = objects[i].GetComponent<Renderer>().material.color;
                objects[i].GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 1.0f - (i * alphaSteps));

            }
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= 1)
        {

            if (Time.time >= next && numObjectsOnline < numberObjects)
            {
                numObjectsOnline++;
                next = Time.time + trailDelay;         

            }

            for (int i = 0; i < numObjectsOnline; i++)
            {


                lerpRatio = objectTimers[i] / lerpDuration; //based on time            
                objectTimers[i] += Time.deltaTime * (speed);
                objects[i].transform.position = new Vector3(0, lerpCurve.Evaluate(lerpRatio) * height, 0);



                if (objectTimers[i] < 0) objectTimers[i] = 0;
                if (objectTimers[i] > lerpDuration) objectTimers[i] = 0;
            }

        }

    }
    void UpdateTrailsAlpha()
    {


    }

}
