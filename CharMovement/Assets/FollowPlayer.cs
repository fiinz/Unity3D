using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Player_Stuck mPlayerStuck;
    private bool pursuing;
    private float vx;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        pursuing = true;
        speed = 9.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        mPlayerStuck = player.GetComponent<Player_Stuck>();
        vx = speed;
        if (transform.position.x > player.transform.position.x)
        {vx = -speed;}
        Debug.Log("vx"+vx);
        transform.localScale=new Vector3(vx/speed,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 0.9f*(1+mPlayerStuck.numEnemiesStack) && pursuing)
        {   vx = 0;
            mPlayerStuck.numEnemiesStack++;
            pursuing = false;
        }
        else
        {
            transform.position+=new Vector3(vx*Time.deltaTime,0,0);    
        }
        
        
        

    }
}
