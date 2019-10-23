using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_SpawnerRow : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int nCols;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < nCols; i++)
        {
            Instantiate(objectToSpawn, new Vector3(i, 0, 0), Quaternion.identity);
        }    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
