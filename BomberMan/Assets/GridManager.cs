using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<Transform> blocks=new List<Transform>();
    private static GridManager _instance;
    public static GridManager instance { get=>_instance; } 


private void Awake()
    {
        _instance = this;        
    }
    // Start is called before the first frame update
    void Start()
    {
        var qt = transform.childCount;
  
        for(int i = 0; i < qt; i++)
        {
            blocks.Add(transform.GetChild(i));
        }
        int x = (int)(1.2f);
        int y = (int)(-1.2f);
        Debug.LogFormat($"x{x} : y{y}");

        //Debug.Log(GetBlockAtPosition(new Vector3(x, y)).name);
    }
    public bool CheckOverlap(Vector3 point)
    {
        var block = blocks.Find(t => t.GetComponent<SpriteRenderer>().bounds.Contains(point));
        if(block)block.GetComponent<SpriteRenderer>().color = Color.yellow;
        return block;
       
    }

    public Transform GetBlockAt( int index)
    {
        return blocks[index];
    }

    
}
