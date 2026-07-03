using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.ChangeMovement<AttackMovementAI>();
    }

    public void Update()
    {
        Transform player = GameObject.FindWithTag("Player")?.transform;
        if (player == null) return;

        float dist = Vector3.Distance(enemy.transform.position, player.position);

        if (dist > 7f)
            enemy.SetState(new PatrolState());
    }

    public void Exit() { }
}
