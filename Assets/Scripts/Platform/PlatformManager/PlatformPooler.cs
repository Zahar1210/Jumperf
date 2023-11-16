using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    [SerializeField] private List<PlatformAbstract> _platformAbstracts;
    [SerializeField] private List<PlatformAbstract> platformPrefab;
    [SerializeField] private PlatformInfo[] platformChance;

    private float _totalChance;
    private int _consecutiveSpawnsGood;
    private int _consecutiveSpawnsBad;
    private PlatformTypes _platformConsecutiveTypes = PlatformTypes.Moving;

    void Start()
    {
        float totalChance = 0f;
        for (int i = 0; i < platformPrefab.Count; i++)
        {
            PlatformAbstract platform = Instantiate(platformPrefab[i]);
            platform.gameObject.SetActive(false);
            _platformAbstracts.Add(platform);
        }

        foreach (var platformInfo in platformChance)
            totalChance += platformInfo.Chance;

        _totalChance = totalChance;
    }

    public PlatformTypes GetRandomType()
    {
        float randomValue = Random.Range(0, _totalChance);
        foreach (var platformInfo in platformChance)
        {
            if (randomValue > platformInfo.Chance) {
                randomValue -= platformInfo.Chance;
            }
            else {
                return platformInfo.PlatformType;
            }
        }

        return PlatformTypes.Original;
    }

    public PlatformAbstract GetPlatformFromPool(PlatformTypes type)
    {
        PlatformAbstract platform = GetPlatformComponent(type);
        if (platform != null)
            return platform;

        return PlatformToSpawn(type);
    }

    private PlatformAbstract GetPlatformComponent(PlatformTypes type)
    {
        foreach (PlatformAbstract platform in _platformAbstracts)
        {
            if (platform != null && platform.PlatformType == type && !platform.gameObject.activeInHierarchy)
                return platform;
        }

        return null;
    }

    private PlatformAbstract PlatformToSpawn(PlatformTypes type)
    {
        PlatformAbstract platform = GetNewPlatform(type);
        PlatformAbstract platformToSpawn = Instantiate(platform);
        _platformAbstracts.Add(platform);
        return platformToSpawn;
    }

    private PlatformAbstract GetNewPlatform(PlatformTypes type)
    {
        PlatformAbstract platform = platformPrefab[18];
        foreach (PlatformAbstract prefab in platformPrefab)
        {
            if (prefab.PlatformType == type)
                return prefab;
        }

        return platform;
    }
}