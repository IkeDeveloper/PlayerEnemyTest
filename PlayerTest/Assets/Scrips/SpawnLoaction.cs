using UnityEngine;

public class SpawnAtLocation : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject playerPrefab;
    public GameObject wallPrefab;      // NEW: assign your wall prefab here
    public EnemyFactory enemyFactory;

    private void Start()
    {
        // Spawn plane
        GameObject plane = Instantiate(planePrefab);
        plane.transform.position = new Vector3(0, 0, 0);

        // color
        plane.GetComponent<Renderer>().material.color = Color.yellow;

        // size (example)
        plane.transform.localScale = new Vector3(10f, 1f, 10f);

        // Build walls around plane
        BuildWallsAroundPlane(plane);

        // Spawn player
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 1, 0);
        player.GetComponent<Renderer>().material.color = Color.green;
        player.tag = "Player";

        // Make camera follow player
        Camera.main.GetComponent<CameraFollow>().target = player.transform;

        // Spawn enemies
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = enemyFactory.CreateEnemy();
            enemy.transform.position = new Vector3(2 + i * 2, 1, 2);

            // INITIAL STATE
            enemy.GetComponent<Enemy>().SetState(new IdleState());
        }
    }

    private void BuildWallsAroundPlane(GameObject plane)
    {
        Renderer r = plane.GetComponent<Renderer>();
        Bounds b = r.bounds;

        Vector3 pos = b.center;
        float halfX = b.extents.x;
        float halfZ = b.extents.z;

        float wallHeight = 5f;
        float wallThickness = 0.5f;

        // LEFT WALL
        GameObject left = Instantiate(
            wallPrefab,
            new Vector3(pos.x - halfX, wallHeight / 2f, pos.z),
            Quaternion.identity
        );
        left.transform.localScale = new Vector3(wallThickness, wallHeight, b.size.z);
        Color wallBlue = new Color(0.2f, 0.4f, 1f); // light neon blue
        left.GetComponent<Renderer>().material.color = wallBlue;



        // RIGHT WALL
        GameObject right = Instantiate(
            wallPrefab,
            new Vector3(pos.x + halfX, wallHeight / 2f, pos.z),
            Quaternion.identity
        );
        right.transform.localScale = new Vector3(wallThickness, wallHeight, b.size.z);
       
        right.GetComponent<Renderer>().material.color = wallBlue;


        // FRONT WALL
        GameObject front = Instantiate(
            wallPrefab,
            new Vector3(pos.x, wallHeight / 2f, pos.z + halfZ),
            Quaternion.identity
        );
        front.transform.localScale = new Vector3(b.size.x, wallHeight, wallThickness);
        front.GetComponent<Renderer>().material.color = wallBlue;

        // BACK WALL
        GameObject back = Instantiate(
            wallPrefab,
            new Vector3(pos.x, wallHeight / 2f, pos.z - halfZ),
            Quaternion.identity
        );
        back.transform.localScale = new Vector3(b.size.x, wallHeight, wallThickness);
        back.GetComponent<Renderer>().material.color = wallBlue;


    }

}