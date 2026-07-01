using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int health = 100;
    public float speed = 2f;

    public void Initialise()
    {
        // Example: make enemy red
        GetComponent<Renderer>().material.color = Color.red;
    }
}

