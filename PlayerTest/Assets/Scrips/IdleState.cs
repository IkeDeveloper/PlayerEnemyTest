using UnityEngine;

public class IdleState : IEnemyState
{
    private Enemy enemy;
    private float timer;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        timer = 0f;
        enemy.ChangeMovement<IdleMovementAI>();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
            enemy.SetState(new PatrolState());
    }

    public void Exit() { }
}
