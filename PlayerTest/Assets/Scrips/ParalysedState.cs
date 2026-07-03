using UnityEngine;

public class ParalysedState : IEnemyState
{
    private Enemy enemy;
    private float timer;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        timer = 0f;

        enemy.ChangeMovement<ParalysedMovementAI>();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 20f)
            enemy.SetState(new IdleState());
    }

    public void Exit() { }
}
