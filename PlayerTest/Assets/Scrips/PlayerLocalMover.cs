using UnityEngine;

public class PlayerLocalMover : MonoBehaviour
{
    public float speed = 5f;

   

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // A/D or Left/Right
        float z = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        // Local-space movement
        Vector3 move =
            transform.right * x +      // local X axis
            transform.forward * z;     // local Z axis

        transform.position += move * speed * Time.deltaTime;
    }
}