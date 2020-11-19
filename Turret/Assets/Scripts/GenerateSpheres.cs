using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    [Header("Configuração das Esferas")]
    public GameObject sphere;
    [Range(1,20)]
    public int divisions=30;
    [Range(1, 20)]
    public int radius=2;
    public const float TAU = 2 * Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        
        radius = 10;
        Debug.Log("TAU" + TAU);
        float angStepOne = TAU / divisions;
        float angStepTwo = angStepOne / 2;

        for (float angTwo = 0.0f; angTwo < TAU /2; angTwo += angStepTwo)
        {
            for (float angOne = 0.0f; angOne < TAU; angOne += angStepOne)
            {
                GameObject go = Instantiate(sphere,Vector3.zero, Quaternion.identity);
                float ax = radius * Mathf.Sin(angTwo) * Mathf.Cos(angOne);
                Debug.Log("ax" + ax);
                float az = radius * Mathf.Sin(angTwo) * Mathf.Sin(angOne);
                float ay = radius * Mathf.Cos(angTwo);
                go.transform.position = new Vector3(ax, ay, az);

            }
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
