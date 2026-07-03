using UnityEngine;

public class WanderState : IEnemyState
{
    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.ChangeMovement<WanderMovementAI>();   // REQUIRED
    }

    public void Update()
    {
        Transform player = GameObject.FindWithTag("Player")?.transform;
        if (player == null) return;

        float dist = Vector3.Distance(enemy.transform.position, player.position);

        if (dist < 5f)
            enemy.SetState(new AttackState());
    }

    public void Exit() { }
}
