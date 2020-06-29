using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public float initalSpawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    private Bounds bounds;
    private Camera mainCamera;
    private Vector2 viewportPoint;

    private int enemySwap = 0;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bounds = rend.bounds;

        InvokeRepeating("SpawnEnemy", initalSpawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        enemySwap++;
        float randomNumX = 0;
        float randomNumY = 0;
        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }
        while (!(viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y > 1))
        {
            randomNumX = Random.Range(bounds.min.x, bounds.max.x);
            randomNumY = Random.Range(bounds.min.y, bounds.max.y);
            viewportPoint = mainCamera.WorldToViewportPoint(new Vector2(randomNumX, randomNumY));
        }
        if (enemySwap == 4)
        {
            Instantiate(enemy2, new Vector2(randomNumX, randomNumY), Quaternion.identity);
            enemySwap = 0;
            spawnDelay /= 10f;
        }
        else
        {
            Instantiate(enemy1, new Vector2(randomNumX, randomNumY), Quaternion.identity);
        }
        viewportPoint = new Vector2(0,0);
    }

    private void updateSpawnDelay(float newDelay)
    {
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0, newDelay);
    }
}
