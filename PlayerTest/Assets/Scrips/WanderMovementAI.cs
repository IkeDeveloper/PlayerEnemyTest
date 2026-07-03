using UnityEngine;

using UnityEngine;

public class WanderMovementAI : MonoBehaviour, IMovementAI
{
    public float speed = 1.5f;
    private Vector3 direction;

    void Start()
    {
        PickNewDirection();
    }

    public void Move()
    {
        if (!this) return;
        // Base wander movement
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Occasionally pick a new direction
        if (Random.value < 0.01f)
            PickNewDirection();

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

        // Blend wander + separation
        direction += separation * 0.5f;   // adjust strength here
        direction = direction.normalized;
    }

    private void PickNewDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized;
    }
}
