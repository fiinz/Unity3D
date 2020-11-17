using UnityEngine;

public class Wander : MonoBehaviour
{

    private Vector3 targetPosition;

    [SerializeField] private float movementSpeed = 1.0f;
   [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float targetPositionTolerance = 0.2f;
    private float minX;
    private float maxX;

    private float minY;
    private float maxY;

    public Transform targetMarker;

    void Start()
    {
        minX = -3.0f;
        maxX = 3.0f;
        minY = -3.0f;
        maxY = 3.0f;
        //Get Wander Position
        GetNextPosition();

    }
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) <= targetPositionTolerance)
        {
            GetNextPosition();
        }
        var dir = (targetPosition - transform.position).normalized;
        var angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg;

        transform.up = Vector3.Slerp(transform.up, dir, rotationSpeed*Time.deltaTime);
        transform.localPosition += transform.up*movementSpeed * Time.deltaTime;
    }

    void GetNextPosition()
    {
        targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        targetMarker.position = targetPosition;
    }
}




           