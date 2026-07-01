using UnityEngine;

[CreateAssetMenu(menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    private static GameConfig _instance;
    public static GameConfig Instance => _instance;

    [Header("Plane")]
    public float planeScale = 10f;
    public Color planeColor = Color.red;

    [Header("Player")]
    public float playerHeightOffset = 1f;

    private void OnEnable()
    {
        _instance = this;
    }
}