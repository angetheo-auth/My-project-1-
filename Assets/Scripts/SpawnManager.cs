using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject rewardPrefab;
    public GameObject finishPrefab;
    private PlayerController playerControllerScript;
    private float startDelay = 2f;
    private Vector3 groundSpawnPosition = new Vector3(46, 0, 0);
    private Vector3 groundSpawnReward = new Vector3(46, 1, 0);
    private Vector3 skySpawnPosition = new Vector3(46, 3, 0);
    private Vector3 skySpawnReward = new Vector3(46, 4, 0);
    private float minSpawnInterval = 1f; 
    private float maxSpawnInterval = 3f;
    public int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        Invoke("SpawnObstacle", startDelay);
        Invoke("SpawnReward", startDelay + minSpawnInterval);
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPosition;
            if (spawnCount >= 4)
            {
                spawnPosition = new Vector3(50, 0, 0);
                Instantiate(finishPrefab, spawnPosition, finishPrefab.transform.rotation);

            }
            else
            {
                spawnPosition = Random.Range(0, 2) == 0 ? groundSpawnPosition : skySpawnPosition;

                Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
                spawnCount++;

                float nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
                Invoke("SpawnObstacle", nextSpawnTime);
            }
                
        }
    }
    void SpawnReward()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPosition = Random.Range(0, 2) == 0 ? groundSpawnReward : skySpawnReward;

            Instantiate(rewardPrefab, spawnPosition, rewardPrefab.transform.rotation);

            float nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            Invoke("SpawnReward", nextSpawnTime);
        }
    }
}