using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCity : MonoBehaviour
{
    public GameObject prefab;
    public float minSpacing;
    public float maxPadding;
    public int minHeight;
    public int maxHeight;
    public int xSize=10;
    public int zSize=10;
    private int oldPadding;
    private int oldxSize;
    private int oldzSize;
    [SerializeField]
    private float xStep;
    [SerializeField]
    private float zStep;
    public int cityBuildings;
    public bool generate = false;
    public bool animated=false;


    private void Start()
    {
        
        xStep = xSize/(int)Mathf.Sqrt(cityBuildings);
        zStep = zSize/(int)Mathf.Sqrt(cityBuildings);       
        
    }

    IEnumerator AnimateHeight(Transform tf,float height)
    {
        while(tf.localScale.y<height){

            tf.localScale=new Vector3(tf.localScale.x,tf.localScale.y+0.2f,tf.localScale.z);
            yield return new WaitForSeconds(0.01f);

        }

        /*if(tf.localScale.y<height) {
            
            tf.localScale=new Vector3(tf.localScale.x,tf.localScale.y+0.2f,tf.localScale.z);
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(AnimateHeight(tf,height));
        }*/
 

    }
    // Update is called once per frame
    void Update()
    {
        if (generate) return;

        for (int zz = 0; zz < (int)Mathf.Sqrt(cityBuildings); zz++)
        {
            for (int xx = 0; xx< (int)Mathf.Sqrt(cityBuildings); xx++)
            {
                var go = Instantiate(prefab);
                var valueSpace = minSpacing;
                go.transform.position = new Vector3(xx * (xStep+ valueSpace), 0.0f, zz * (zStep+ valueSpace));
                go.transform.localScale=new Vector3(1,0,1);
                if(animated)
                StartCoroutine(AnimateHeight(go.transform, Random.Range(minHeight, maxHeight)));
                else
                go.transform.localScale = new Vector3(1, Random.Range(minHeight, maxHeight),1);
            }
        }
        generate = true;
    }
}
