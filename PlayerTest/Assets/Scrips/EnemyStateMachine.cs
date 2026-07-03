using UnityEngine;

public class EnemyStateMachine
{
    private IEnemyState currentState;
    private Enemy enemy;

    public EnemyStateMachine(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void ChangeState(IEnemyState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter(enemy);
    }

    public void Update()
    {
        currentState?.Update();
    }
}
