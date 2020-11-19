using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject pfPlayerShootVFX; //particulas quando acerto
    public GameObject pfMissShootVFX; //particulas quando falho


    private GameObject player;
    public Transform firePos;
    public Light muzzle;
    public Light danger;

    private Transform head;
    public float maxDist;
    public float minDist;
    public float speed;
    public float rate = 0.2f;
    public float nextAttack;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        head = transform.GetChild(0);
    }
    void Start()
    {
        nextAttack = Time.time + rate;
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 dif = player.transform.position - head.transform.position;
        float dist = dif.magnitude;
        Vector3 dir = dif.normalized;
        if(dist>minDist && dist < maxDist)
        {
            head.transform.forward = Vector3.Slerp(head.transform.forward, dir, Time.deltaTime*speed);
            float dot=Vector3.Dot(head.transform.forward, dir);
            if (dot > 0.8) 
            {
                if (Time.time > nextAttack)
                {               
                    Shoot(head.transform.forward);
                    nextAttack = Time.time + rate;
                }
            }
            else {  }
            //float dot 
        }
          
        // head.transform.localRotation = Quaternion.Euler(new Vector3(0, rot, 0));
        //head.transform.localRotation = Quaternion.Euler(new Vector3(0, rot, 0));
        //head.transform.localRotation = Quaternion.AngleAxis(rot, head.transform.up);
        // Quaternion tarRot = Quaternion.LookRotation(dir);
        //  head.transform.localRotation = Quaternion.Slerp(head.transform.rotation, tarRot,Time.deltaTime);
        //head.transform.forward =
    }
    void Shoot(Vector3 dir)
    {
        muzzle.enabled = true;
        Invoke("DisableMuzzle", rate / 2);
        RaycastHit hit;
        
        Physics.Raycast(firePos.position, dir, out hit, maxDist);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == player)
            {
                
                var temp=Instantiate(pfPlayerShootVFX);
                temp.transform.position = hit.point;
                temp.transform.forward = (transform.position - temp.transform.position).normalized;
                //colidiu com o player
            }
            else
            {
                var temp = Instantiate(pfMissShootVFX);
                temp.transform.position = hit.point;
                temp.transform.forward = Vector3.up;
                //chao
            }
            
        }


    }
    void DisableMuzzle()
    {
        muzzle.enabled = false;
    }
}
