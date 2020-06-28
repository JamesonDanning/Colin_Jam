﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public float initalSpawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    private Bounds bounds;
    private Camera mainCamera;
    private Vector2 viewportPoint;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bounds = rend.bounds;

        InvokeRepeating("spawnObject", initalSpawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObject()
    {
        float randomNumX = 0;
        float randomNumY = 0;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        while (!(viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y > 1))
        {
            randomNumX = Random.Range(bounds.min.x, bounds.max.x);
            randomNumY = Random.Range(bounds.min.y, bounds.max.y);
            viewportPoint = mainCamera.WorldToViewportPoint(new Vector2(randomNumX, randomNumY));
            Debug.Log("Min x bound: " + bounds.min.x + ", Max x bound: " + bounds.max.x);
            Debug.Log("Min y bound: " + bounds.min.y + ", Max y bound: " + bounds.max.y);
            Debug.Log(viewportPoint);
        }
        Instantiate(enemy1, new Vector2(randomNumX, randomNumY), Quaternion.identity);
        viewportPoint = new Vector2(0,0);
    }
}