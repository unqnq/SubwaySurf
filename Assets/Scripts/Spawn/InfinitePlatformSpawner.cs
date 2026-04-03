using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformSpawner : PlatformsSpawner
{
    private Transform playerTransform;
    private List<GameObject> activePlatforms = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.Find("PlayerModel").transform;
        GenerateStart();
    }

    protected override void SpawnPlatform(Platform spawnPlatform)
    {
        Debug.Log("transform.forward * spawnDirection: " + transform.forward * spawnDirection);
        Debug.Log("transform.forward: " + transform.forward);
        Debug.Log("spawnDirection: " + spawnDirection);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, spawnDirection);
        GameObject newPlatform = Instantiate(spawnPlatform, spawnPos, transform.rotation).gameObject;
        spawnDirection += platformLength;
        activePlatforms.Add(newPlatform);
    }

    private void RemoveActivePlatforms()
    {
        GameObject lostPlatform = activePlatforms[0];
        activePlatforms.RemoveAt(0);
        Destroy(lostPlatform);
    }

    void Update()
    {
        if (playerTransform.position.z > spawnDirection - (maxPlatformCount * platformLength))
        {
            SpawnPlatform(GetRandomPlatform());
            RemoveActivePlatforms();
        }
    }
}
