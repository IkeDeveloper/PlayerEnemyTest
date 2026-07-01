using UnityEngine;

public abstract class GameObjectFactory : ScriptableObject
{
    public abstract GameObject CreateGameObject(Vector3 position, Quaternion rotation);
}
