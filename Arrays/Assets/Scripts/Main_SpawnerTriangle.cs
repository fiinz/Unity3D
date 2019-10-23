using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_SpawnerTriangle : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int triangleBase;
   // public int nRows;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < triangleBase; i++)
        {
            for (int j = 0; j < triangleBase - i; j++)
            {
                Instantiate(objectToSpawn, new Vector3(j+(i*0.5f), i, 0), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
