using UnityEngine;

[CreateAssetMenu(menuName = "Factories/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;

    public GameObject CreateEnemy()
    {
        // Clone the prefab using the Clone script
        Clone clone = enemyPrefab.GetComponent<Clone>();
        GameObject enemy = clone.Copy();

        // Initialise enemy behaviour
        IEnemy enemyInterface = enemy.GetComponent<IEnemy>();
        if (enemyInterface != null)
        {
            enemyInterface.Initialise();
        }

        return enemy;
    }
}
