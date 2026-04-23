using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] protected List<Platform> platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLength;

    protected float spawnDirection;

    protected void LoadPlatforms()
    {
        platforms = Resources.LoadAll<Platform>("Platforms/").ToList();
    }
    protected Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Count);
        return platforms[randomIndex];
    }

    protected virtual void SpawnPlatform(Platform spawnPlatform)
    {
        Vector3 spawnPos = new Vector3(-2, 0, spawnDirection);
        Instantiate(spawnPlatform,spawnPos,transform.rotation);
        spawnDirection += platformLength;
    }
    void Start()
    {
        GenerateStart();
        LoadPlatforms();
    }

    public void GenerateStart()
    {
        SpawnPlatform(startPlatform);
        for (int i = 0; i < maxPlatformCount; i++)
        {
            SpawnPlatform(GetRandomPlatform());
        }
    }
}
