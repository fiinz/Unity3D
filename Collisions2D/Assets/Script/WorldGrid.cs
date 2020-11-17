using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    public static WorldGrid instance { get; private set; }
    public Transform[,] grid = new Transform[5, 5];
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(this); }

        var temp = GameObject.FindGameObjectsWithTag("Block");

        for (int i = 0; i < temp.Length; i++)
        {
            grid[(int)temp[i].transform.localPosition.y,(int) temp[i].transform.localPosition.x] = temp[i].transform;
        }
        
    }

    public void ShowClosestBlock(Vector3 position)
    {
        if (grid == null) return;
        Transform closest = null;
        float dist = 10;
        for (int y = 0; y < grid.GetLength(0); y++)
        {

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] == null) continue;
                float tempDist = Vector3.Distance(position, grid[x, y].position);
                if (tempDist < dist)
                {
                    dist = tempDist;
                    closest = grid[x, y];
                }



            }
        }

        if (closest)
            closest.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

    }

    public Transform GetBlockAt(Vector2 pos)
    {
        //by truncate the pos we get the imediate bellow position
        var temp = grid[(int)pos.y, (int)pos.x];
        if (temp != null)
        {
            temp.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        return temp;
    }


}
