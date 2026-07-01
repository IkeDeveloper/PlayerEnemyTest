using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int health = 100;
    public float speed = 2f;

    private IMovementAI movementAI;

    public void Initialise()
    {
        // Example: make enemy red
        GetComponent<Renderer>().material.color = Color.red;

        // Find whichever movement script was added at runtime
        movementAI = GetComponent<IMovementAI>();
    }

    private void Update()
    {
        // Run the movement pattern for THIS enemy
        movementAI?.Move();
    }
}

