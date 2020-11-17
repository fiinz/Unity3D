using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints; // path waypoints given by positions
    //is allow to show the path in editor
    public bool isDebug = true;
    public float radius = 2.0f; // isto funciona como uma tolerância para chegar ao caminho;

    //Get the Path Length
    public float PathLength {
        get => waypoints.Length;        
    }
    /// <summary>
    /// Method to get a waypoint given an index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetPoint(int index)
    {
        return waypoints[index];
    }

    public void OnDrawGizmos()
    {
        if (isDebug)
        {
            Gizmos.color = Color.magenta;
            for(int i = 0; i < waypoints.Length; i++)
            {
                if ((i + 1) < waypoints.Length)
                {
                    Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
                }
            }
        }
    }
   
}
