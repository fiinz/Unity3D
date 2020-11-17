using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stuck : MonoBehaviour
{
    public int numEnemiesStack;

    public bool isStuck = false;
    public PlayerController pController;
    public List<GameObject> enemies=new List<GameObject>();
    public Queue<int> moves;
    public float DequeueTimer;
    public float DequeueRate;
    public int previousMove;
    // Start is called before the first frame update
    void Start()
    {
        previousMove = 0;
        pController = GetComponent<PlayerController>();

    }

    void AddEnemy(GameObject go)
    {
        enemies.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        isStuck = false;
        if (numEnemiesStack > 0) isStuck = true;
        if(pController.axisX!=previousMove){moves.Enqueue(1);}

        if (Time.time > DequeueTimer)
        {
            DequeueTimer = Time.time + DequeueRate;
            moves.Dequeue();
        }

        if (moves.Count > 3)
        {
            numEnemiesStack = 0;
            
        }

    }
}
