using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float playerHealth;
    private Player_Stuck mPlayerStuck;
   
    // Start is called before the first frame update
    void Start()
    {
        mPlayerStuck = GetComponent<Player_Stuck>();
        playerHealth = 100;
    }

    public void DeductHealth()
    {
        
        
    }

    public void IncreaseHealth()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth -= mPlayerStuck.numEnemiesStack*20 *Time.deltaTime;


    }
}
