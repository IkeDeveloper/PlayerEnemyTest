using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // The player to follow
    public Vector3 offset = new Vector3(0, 10, -15);   // Default chase-camera offset
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Smooth follow movement
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        // Always look at the player
        transform.LookAt(target);
    }
}
