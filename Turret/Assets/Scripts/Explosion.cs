using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var colliders = Physics.OverlapSphere(transform.position, 2); // faz cast de uma esfera para detetar colisões num raio de 2 unidades
        if (colliders != null) // se obteve colliders do cast
        {
            foreach (var col in colliders)
            {
                var rgb = col.GetComponent<Rigidbody>(); //tenta obter um component rigid body dos objetos com os quais colidiu
                if(rgb)
                rgb.AddExplosionForce(100, transform.position, 2); // aplica uma forma explosiva com raio dois

            }

        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
