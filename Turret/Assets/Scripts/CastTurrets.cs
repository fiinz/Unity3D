using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CastTurrets : MonoBehaviour
{
    [SerializeField] GameObject turretPF;
    [SerializeField] GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            marker.SetActive(true);
            RaycastHit hit;
            Debug.LogFormat($"mouse {Input.mousePosition}");
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            //Camera.main.Screen
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                marker.transform.position = hit.point+hit.normal*0.01f;
                marker.transform.forward = -hit.normal; 
                if (Input.GetMouseButtonDown(0))
                {
                    var colliders=Physics.OverlapSphere(hit.point, 1);
                    if (colliders!=null)
                    {
                        for (int i = 0; i < colliders.Length; i++)
                        {
                            //if (colliders[i] != hit.collider) return;
                            if (colliders[i].transform.tag == "Explosive")
                            {
                                var rb=colliders[i].GetComponent<Rigidbody>();
                                rb.AddExplosionForce(50.0f, hit.point, 1,1.5f,ForceMode.Impulse);
                            }
                        }


                    }
                    
                    //var temp = Instantiate(turretPF);
                    //temp.transform.position = hit.point;

                }

            }            
        }
        else
        {
            marker.SetActive(false);
        }
        
    }
}
