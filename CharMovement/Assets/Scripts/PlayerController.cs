using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int axisX; //will allow the movement to check the input of the player in X
    public int axisY; //will allow the movement to check the input of the player in Y
    public bool buttonA;
    public bool buttonB;
    
    //timer system - preventing the system to process multiple inputs from the attacks
    public float attackRate;
    public float nextAttack;

    // Start is called before the first frame update
    void Start()
    {
        //the next attack its previewed to happen now
        nextAttack = Time.time;
        //the attack rate
        attackRate = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        axisX = 0;
        axisY = 0;
        buttonA = false;
        buttonB = false;

        //he can attack
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= nextAttack)
        {
            axisX = 0;
            buttonA = true;
            //now the next attack will only occur on time.time + rate
            nextAttack = Time.time + attackRate;
        }
        else if (Input.GetKeyDown(KeyCode.X) && Time.time >= nextAttack)
        {
            axisX = 0;
            buttonB = true;
            nextAttack = Time.time + attackRate;
        }
        else
        {
            
            //else if because he shouldnt be able to move to left and right at same time
            if (Input.GetKey(KeyCode.LeftArrow))
            {axisX = -1;}
            else if (Input.GetKey(KeyCode.RightArrow))
            {axisX = 1;}
            
            //but the  jump and crouch independently of x
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {axisY = 1;}
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                axisY = -1;
                
            }
         }



    }
}
