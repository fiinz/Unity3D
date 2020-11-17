using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransform : MonoBehaviour
{
    public Vector2 localPoint;
    public Vector2 worldPoint;
    public Vector2 worldToLocalPoint;
    public Transform localObject;

    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnDrawGizmos()
    {
        DrawBasisVectors(transform.position, transform.right, transform.up);
        DrawBasisVectors(Vector2.zero, Vector2.right, Vector2.up);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(LocalToWorld(localPoint), 0.1f);
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(WorldToLocal(worldPoint), 0.1f);

        localObject.localPosition= WorldToLocal(worldPoint);

    }
    Vector2 WorldToLocal(Vector2 worldpoint)
    {
        //obter o ponto world space relativamente à posicao de origem do local space
        Vector2 relativePoint = worldPoint-(Vector2)transform.position;
        Vector2 projectedRelativeVector;
        //projectedRelativeVector.x = relativePoint.x* transform.right.x;

        //o que me confundiu aqui é porque é que nao poderia isolar logo o X dado que estou
        // a projetar no right
        // o problema é que aqui o right pode não ser um vetor 1,0,0
        // o right pode ser um vetor 0.5,0.5 ( por exemplo) , dai ser necessário o .dot

        projectedRelativeVector.x = Vector2.Dot(relativePoint,transform.right);

        projectedRelativeVector.y = Vector2.Dot(relativePoint,transform.up);
       // projectedRelativeVector.y = relativePoint.y * transform.up.y;
        worldToLocalPoint = projectedRelativeVector;
        return (Vector2)projectedRelativeVector;

    }
    Vector2 LocalToWorld(Vector2 localPos)
    {
        //aqui projetas em right e up nao precisas de fazer o dot completo porque
        //o vetor de Origem em World nao roda.

        Vector2 offset = localPos.x * transform.right + localPos.y * transform.up;
        return (Vector2)transform.position + offset;

    }
    void DrawBasisVectors(Vector2 pos, Vector2 right, Vector2 up)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(pos, up);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pos, right);



    }
    // Update is called once per frame
    void Update()
    {



    }
}
