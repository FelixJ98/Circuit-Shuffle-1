using UnityEngine;
public class FanBlow : MonoBehaviour
{
    [Header("Fan Settings")]
    public float pushForce = 10f;
    public float distance = 5f;
    public Vector3 raycastOffset = Vector3.zero;
    
    void Update()
    {
        Vector3 raycastStart = transform.position + raycastOffset;
        
        RaycastHit hit;
        if (Physics.Raycast(raycastStart, transform.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                CharacterController controller = hit.collider.GetComponent<CharacterController>();
                if (controller != null)
                {
                    Vector3 pushDirection = (hit.point - raycastStart).normalized;
                    Vector3 pushVector = pushDirection * (pushForce * Time.deltaTime);
                    controller.Move(pushVector);
                }
            }
        }
    }
    
    void OnDrawGizmos()
    {
        Vector3 raycastStart = transform.position + raycastOffset;
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(raycastStart, transform.forward * distance);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(raycastStart, 0.1f);
    }
}
