using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLerp2D : MonoBehaviour
{
    public bool useTarget;
    public Transform targetObject;
    private Vector3 targetPos;
    private Vector3 originalPos;
    public float height = 2;
    [Range(0, 1)]
    public float lerpRatio;
    // Start is called before the first frame update
    void Awake()
    {
        originalPos = transform.position;
        if (!useTarget && targetObject != null) { targetPos = Random.onUnitSphere * 5; targetObject.position = targetPos; }
    }

    // Update is called once per frame
    void Update()
    {

        if (useTarget) { targetPos = targetObject.position; }
        Vector3 dif = targetPos - originalPos;
        Vector3 dir = dif.normalized;

        Vector3 midPoint=Lerp(originalPos, targetPos, lerpRatio);// calculo do midpoint
        midPoint = new Vector3(midPoint.x, midPoint.y+height, midPoint.z); //acrescentar h ao mid point
        
        float distance = dif.magnitude;

        if (targetPos != null)
        {
            if(lerpRatio<0.5)
            transform.position = Lerp(originalPos, midPoint, lerpRatio*2);
            else
            transform.position = Lerp(midPoint, targetPos,(lerpRatio-0.5f)*2);

        }
    }
     Vector3 Lerp(Vector3 posa, Vector3 posb, float lerpRatio)
    {
        return posa + (posb - posa) * lerpRatio;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, targetPos);

    }
}
