using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformsSpawner : PlatformsSpawner
{
    private Transform playerTransform;
    private List<GameObject> activePlatforms =
    new List<GameObject>();

    protected override void SpawnPlatform(Platform spawnPlatform)
    {
        Vector3 spawnPos = new Vector3(-2, 0, spawnDirection);
        GameObject newPlatform = Instantiate(spawnPlatform, spawnPos, transform.rotation).gameObject;
        spawnDirection += platformLength;
        activePlatforms.Add(newPlatform);
    }
    void Start()
    {
        playerTransform = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
        GenerateStart();
        LoadPlatforms();
    }

    void RemoveActivePlatforms()
    {
        GameObject lostPlatform = activePlatforms[0];
        activePlatforms.RemoveAt(0);
        Destroy(lostPlatform);
    }

    void Update()
    {
        Debug.Log("playerTransform.position.x: " + playerTransform.position.x + " > " + (spawnDirection - (maxPlatformCount * platformLength)));
        if(playerTransform.position.z > spawnDirection - (maxPlatformCount * platformLength))
        {
            SpawnPlatform(GetRandomPlatform());
            // RemoveActivePlatforms();
        }
    }
}
