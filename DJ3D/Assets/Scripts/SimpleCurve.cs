using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCurve : MonoBehaviour
{
    public AnimationCurve lerpCurve;


    private float lerpRatio;
    public float lerpDuration;
    public float height = 1;
    private float currentTime;    

      

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= 1)
        {
            lerpRatio = currentTime / lerpDuration; //based on time            
            currentTime += Time.deltaTime;
            gameObject.transform.position = new Vector3(0, lerpCurve.Evaluate(lerpRatio) * height, 0);

            if (currentTime < 0) currentTime = 0;
            if (currentTime > lerpDuration) currentTime = 0;
        }

    }

}



