using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float force = 50.0f;
    [SerializeField] private float minimumAvoidanceDistance = 20.0f;
    [SerializeField] private float toleranceRadius = 3.0f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private Vector3 targetPoint;
    [SerializeField] private RaycastHit2D avoidanceHit;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 hitNormal;
    [SerializeField] private LayerMask colisions;

    //o Input aqui de rato é para obter uma nova direção
    void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            //não é necessário fazer ray , não há noção de altura n faz sentido
            var temp= Camera.main.ScreenToWorldPoint(Input.mousePosition); //aqui sim,
            targetPoint = new Vector3(temp.x, temp.y, 0);//ignorar a coordenada 0 e colocar hardcoded
            Debug.Log("tp"+ targetPoint);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ApplyAvoidance(ref Vector3 direction)
    {
     
        avoidanceHit = Physics2D.Raycast(transform.position, direction, minimumAvoidanceDistance, colisions);
        if (avoidanceHit.collider != null)
        {
           // Debug.Log
            hitNormal = avoidanceHit.normal;
            hitNormal.z = 0; // não interessa a posição z
            direction = transform.up + hitNormal * force;

        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        //o target point foi calculado através do rato;
        //e obtem a direção
        var dif = (targetPoint - transform.position);
        direction = dif.normalized;      

        ApplyAvoidance(ref direction); //aplicar o avoidance

        if (dif.magnitude < toleranceRadius) return; // já chegou ao ponto deve parar
        currentSpeed = movementSpeed * Time.deltaTime;
        //tratar das rotações
        transform.up = Vector3.Slerp(transform.up, direction,rotationSpeed*Time.deltaTime);
        transform.position += transform.up * currentSpeed;



    }
}
