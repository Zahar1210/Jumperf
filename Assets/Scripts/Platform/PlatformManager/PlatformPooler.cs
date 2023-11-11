using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformPooler : MonoBehaviour
{
    [SerializeField] private List<PlatformAbstract> platformPrefab;
    [SerializeField] private PlatformInfo[] platformChance;
    private float _totalChance;

    void Start()
    {
        float totalChance = 0f;
        for (int i = 0; i < platformPrefab.Count; i++)
        {
            PlatformAbstract platform = Instantiate(platformPrefab[i]);
            platform.gameObject.SetActive(false);
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
            if (randomValue > platformInfo.Chance)
                randomValue -= platformInfo.Chance;

            else
                return platformInfo.PlatformType;
        }

        return PlatformTypes.Original;
    }

    public PlatformAbstract GetPlatformFromPool(PlatformTypes type)
    {
        PlatformAbstract platform = GetPlatformComponent(type);
        if (platform != null)
        {
            return platform;
        }
        return PlatformToSpawn(type);;
    }

    private PlatformAbstract GetPlatformComponent(PlatformTypes type)
    {
        // if (type == PlatformTypes.Start)
        //     GetRandomType();
        PlatformAbstract[] platforms = Resources.FindObjectsOfTypeAll<PlatformAbstract>();
        foreach (PlatformAbstract platform in platforms)
        {
            if (platform != null && platform.PlatformType == type && !platform.IsActive)
                return platform;
        }
        return null;
    }

    private PlatformAbstract PlatformToSpawn(PlatformTypes type)//наверно костыль
    {
        PlatformAbstract platform = GetNewPlatform(type);
        PlatformAbstract platformToSpawn = Instantiate(platform);
        return platformToSpawn;
    }

    private PlatformAbstract GetNewPlatform(PlatformTypes type)
    {
        PlatformAbstract platform = platformPrefab[18];//индеекс платформы по умелчанию пока так для того чтобы всегда брали на запас
        foreach (PlatformAbstract prefab in platformPrefab)
        {
            if (prefab.PlatformType == type)
                return prefab;
        }

        return platform;
    }
}