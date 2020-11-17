using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity=0.5f;
    [SerializeField] private Vector3 velocity;
    public float speed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {

        velocity = new Vector3(0, -gravity, 0);
    }

 

    // Update is called once per frame
    void Update()
    {
        velocity += Vector3.down *gravity;
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity= new Vector3(0, jumpForce, 0);
        }

        transform.position += velocity * Time.deltaTime;

        var temp = Block.CheckBlockIntersetion(transform.position - new Vector3(0.5f, 0.5f));

        if (temp == null) 
        {
            temp= Block.CheckBlockIntersetion(transform.position + new Vector3(0.5f, -0.5f));
        }
               
        if (temp!=null)
        {
            temp.GetComponent<SpriteRenderer>().color = Color.yellow;

            //transform.position -= velocity * Time.deltaTime;
           transform.position= new Vector3(transform.position.x, temp.position.y + 0.5f, 0);
            //var dist = transform.position.y - GetBlockBellow().position.y;

            //   transform.position = new Vector3(transform.position.x, GetBlockBellow().position.y + 0.5f, 0);
            velocity = new Vector3(velocity.x, 0.0f, 0.0f);
            

        }
       
    }
}
