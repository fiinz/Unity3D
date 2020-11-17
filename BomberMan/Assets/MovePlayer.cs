using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float vx, vy;
    private float speed = 2.0f;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;
        currentSpeed = Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.RightArrow)) { vx = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) {  vx += -1; }
        if (Input.GetKey(KeyCode.DownArrow)) { vx = 0; vy = -1; }
        if (Input.GetKey(KeyCode.UpArrow)) { vx = 0; vy += 1; }

        // bool col = false;
        var targetPos = new Vector3(transform.position.x + vx* currentSpeed, transform.position.y + vy* currentSpeed, 0);
        Vector2 topLeft = new Vector2(targetPos.x-0.499f,targetPos.y + 0.499f);
        Vector2 topRight = new Vector2(targetPos.x+0.499f, targetPos.y + 0.499f);
        Vector2 bottomLeft = new Vector2(targetPos.x - 0.499f, targetPos.y-0.499f);
        Vector2 bottomRight = new Vector2(targetPos.x + 0.499f, targetPos.y-0.499f);


        if (GridManager.instance.CheckOverlap(topLeft)) return;
        if (GridManager.instance.CheckOverlap(topRight)) return;
        if (GridManager.instance.CheckOverlap(bottomLeft)) return;
        if (GridManager.instance.CheckOverlap(bottomRight)) return;



        transform.position += new Vector3(vx, vy, 0) * currentSpeed;
    
        
    }
}
