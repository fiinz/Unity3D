using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //a static reference to all the blocks inside the scene.
    public static List<Transform> blocks=new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        blocks.Add(transform);        
    }


    public static Transform CheckBlockIntersetion(Vector3 point)
    {
        var temp = Block.blocks.Find(t => t.GetComponent<SpriteRenderer>().bounds.Contains(point));
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
