using UnityEngine;

using UnityEngine;

public class AttackMovementAI : MonoBehaviour, IMovementAI
{
    public float speed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    public void Move()
    {
        if (!this) return;
        if (player == null) return;

        // Base chase direction
        Vector3 dir = (player.position - transform.position).normalized;

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

        // Blend chase + separation
        dir += separation * 0.5f;   // adjust strength here
        dir = dir.normalized;

        // Apply movement
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}
