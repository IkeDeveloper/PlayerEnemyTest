using UnityEngine;



public class PatrolMovementAI : MonoBehaviour, IMovementAI
{
    public Transform[] points;
    public float speed = 2f;
    private int index = 0;

    public void Move()
    {
        if (!this) return;
        if (points == null || points.Length == 0) return;

        // Base patrol direction
        Transform target = points[index];
        Vector3 dir = (target.position - transform.position).normalized;

        // --- Separation Steering ---
        Collider[] hits = Physics.OverlapSphere(transform.position, 1f);
        Vector3 separation = Vector3.zero;

        foreach (var h in hits)
        {
            if (h.transform != transform && h.GetComponent<Enemy>())
            {
                Vector3 away = transform.position - h.transform.position;
                separation += away.normalized;
            }
        }

        // Blend patrol + separation
        dir += separation * 0.5f;   // adjust strength here
        dir = dir.normalized;

        // Apply movement
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        // Patrol point switching
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
            index = (index + 1) % points.Length;
    }
}
