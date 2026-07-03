using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        // MovementAI handles actual movement

        enemy.ChangeMovement<PatrolMovementAI>();
    }

    public void Update()
    {
        // Example transition
        if (Vector3.Distance(enemy.transform.position, GameObject.FindWithTag("Player").transform.position) < 5f)
            enemy.SetState(new AttackState());
    }

    public void Exit() { }
}

