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
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}
