using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    [Header("Configuração das Esferas")]
    public GameObject cube;
    [Range(1,500)]
    public int piramidBase;
    public int piramidHeight;
    // Start is called before the first frame update
    void Start()
    {
        for (int yy = 0; yy< piramidHeight; yy++)
        {
            for (int xx = 0; xx < piramidBase; xx++)
            {
                for (int zz = 0; zz < piramidBase; zz++)
                {
                    GameObject go = Instantiate(cube, Random.onUnitSphere * 5, Quaternion.identity);
                    go.transform.position += Vector3.up * 5;

                }
            }
        }          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
