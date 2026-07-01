using UnityEngine;

public class PatrolMovementAI : MonoBehaviour, IMovementAI
{
    public Transform[] points;
    public float speed = 2f;
    private int index = 0;

    public void Move()
    {
        if (points == null || points.Length == 0) return;

        Transform target = points[index];
        Vector3 dir = (target.position - transform.position).normalized;

        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
            index = (index + 1) % points.Length;
    }
}

