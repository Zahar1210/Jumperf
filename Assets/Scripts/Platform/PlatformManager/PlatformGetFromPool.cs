using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformGetFromPool : MonoBehaviour
{
    [SerializeField] private float maxInterval;
    [SerializeField] private float minInterval;
    [SerializeField] private PlatformSpawner platformSpawner;


    [SerializeField] private GameObject point;
    
    private float _spawnDistanceInterval;
    private float _lastSpawnPosition;

    private void Start()
    {
        _lastSpawnPosition = transform.position.y;
    }

    private void Update()
    {
        float currentYPosition = transform.position.y;
        if (currentYPosition - _lastSpawnPosition >= _spawnDistanceInterval)
        {
            _spawnDistanceInterval = RandomInterval();
            platformSpawner.SpawnPlatform();
            _lastSpawnPosition = currentYPosition;
           // Instantiate(point, transform.position, quaternion.identity);
        }
    }

    private float RandomInterval()
    {
        return Random.Range(minInterval, maxInterval);
    }
}