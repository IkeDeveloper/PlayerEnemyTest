
using UnityEngine;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int health = 100;
    public float speed = 2f;

    private IMovementAI movementAI;
    private EnemyStateMachine stateMachine;

    public void Initialise()
    {
        GetComponent<Renderer>().material.color = Color.red;

        // Movement script added by spawner
        movementAI = GetComponent<IMovementAI>();

        // Create the state machine. Each enemy has access to the state machine and can change its state.
        stateMachine = new EnemyStateMachine(this);

        // Start in Idle
        stateMachine.ChangeState(new IdleState());
    }

    private void Update()
    {
        if (movementAI!= null)   
            movementAI?.Move();
        stateMachine.Update();
    }

    public void SetState(IEnemyState newState)
    {
        stateMachine.ChangeState(newState);
    }

    // Clean movement swapping helper
    public void ChangeMovement<T>() where T : MonoBehaviour, IMovementAI
    {
        // Destroy old movement scripts immediately
        foreach (var ai in GetComponents<IMovementAI>())
            DestroyImmediate(ai as MonoBehaviour);

        // Add new movement script
        gameObject.AddComponent<T>();

        // Reassign movementAI
        movementAI = GetComponent<IMovementAI>();
    }


}
