using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSpheres : MonoBehaviour
{

    [SerializeField]
    //private GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] go=null;

        if (go !=null)
        {
            for(int i = 0; i < go.Length; i++)
            {
                var tmp = go[i].GetComponent<RandomMaterialColor>();
                if (tmp)
                {
                //    tmp.enabled = true;
                }             
            
            }            

        }
        RandomMaterialColor[] mRefs = GameObject.FindObjectsOfType<RandomMaterialColor>();
        for (int i = 0; i < mRefs.Length; i++)
        {
            mRefs[i].enabled = true;
        }

    }
    // Update is called once per frame
    void Update()
    {

              /*
      
        */

    }
}
