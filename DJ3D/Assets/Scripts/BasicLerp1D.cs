using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLerp1D : MonoBehaviour
{
    public bool useTarget;
    public Transform targetObject;
    private Vector3 targetPos;
    private Vector3 originalPos;
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
        float distance = dif.magnitude;

        if (targetPos != null)
        {
            transform.position = Lerp(originalPos, targetPos, lerpRatio);

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
