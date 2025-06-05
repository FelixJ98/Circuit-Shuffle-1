using UnityEngine;

public class SpinningBlades : MonoBehaviour
{
    [Header("Moves between points")]
    public Transform pointA;
    public Transform pointB;
    
    [Header("Speed Settings")]
    public float moveSpeed = 2f;
    public float rotateSpeed = 360f; //per second
    
    private bool movingToB = true;
    
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        MoveBetweenPoints();
    }
    
    void MoveBetweenPoints()
    {
        if (pointA == null || pointB == null) return;
        
        Vector3 targetPosition = movingToB ? pointB.position : pointA.position;
        
        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Check if reached target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
