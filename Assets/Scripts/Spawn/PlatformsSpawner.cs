using UnityEngine;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLength;
    protected float spawnDirection;

    protected Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        return platforms[randomIndex];
    }

    protected virtual void SpawnPlatform(Platform spawnPlatform)
    {
        Instantiate(spawnPlatform, transform.forward * spawnDirection, transform.rotation);        
        spawnDirection += platformLength;
    }

    protected virtual void GenerateStart()
    {
        SpawnPlatform(startPlatform);
        for(int i = 0; i < maxPlatformCount; i++)
        {
            SpawnPlatform(GetRandomPlatform());
        }
    }
}
