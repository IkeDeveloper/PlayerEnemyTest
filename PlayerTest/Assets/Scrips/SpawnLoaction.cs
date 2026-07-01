using UnityEngine;

public class SpawnAtLocation : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public CameraFollow cameraFollow;
    public EnemyFactory enemyFactory;

    void Start()
    {

        var cfg = GameConfig.Instance;

        // Spawn the plane
        GameObject plane = Instantiate(
            planePrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        plane.transform.localScale = new Vector3(
            cfg.planeScale,
            plane.transform.localScale.y,
            cfg.planeScale
        );
        plane.GetComponent<Renderer>().material.color = cfg.planeColor;

        // Spawn the player ON TOP of the plane
        Vector3 playerPos = plane.transform.position + new Vector3(0, cfg.playerHeightOffset, 0);
        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);

        // Camera follows the player
        if (cameraFollow != null)
        {
            cameraFollow.target = player.transform;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = enemyFactory.CreateEnemy();
            enemy.transform.position = new Vector3(
            2 + i * 2,   // spread enemies out
            1,
            2
            );
        }
    }
}
            
    

