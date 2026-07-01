using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject Copy()
    {
        return Instantiate(gameObject);
    }
}

