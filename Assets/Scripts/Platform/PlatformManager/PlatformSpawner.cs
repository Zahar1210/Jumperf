using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private BonusPooler bonusPooler;
    [SerializeField] private PlatformPooler platformPooler;
    [SerializeField] private MainData mainData;
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private int maxConsecutiveSpawns;
    [SerializeField] private List<PlatformTypes> goodPlatformTypes;
    [SerializeField] private List<PlatformTypes> badPlatformTypes;

    private int _consecutiveSpawns;
    private int _spawnCount;
    private float _time;
    private PlatformTypes _randomType;

    public void SpawnPlatform()
    {
        GetRandomType();
    }

    private void GetRandomType()
    {
        _randomType = platformPooler.GetRandomType();
        TryPlatformType();
    }

    private void TryPlatformType()
    {
        if (goodPlatformTypes.Contains(_randomType))
        {
            SpawnPlatformObject(_randomType);
        }
        else if (badPlatformTypes.Contains(_randomType))
        {
            _consecutiveSpawns++;
            if (_consecutiveSpawns <= maxConsecutiveSpawns)
            {
                SpawnPlatformObject(_randomType);
            }
            else
            {
                GetRandomType();
                _consecutiveSpawns = 0;
            }
        }
    }

    private void PlatformSpawn(PlatformAbstract platform, Vector2 platformPosition, BonusAbstract bonus = null)
    {
        platform.EnablePlatform(true);
        platform.transform.position = platformPosition;
        if (bonus != null)
        {
            platform.Bonus = bonus;
            bonus.EnableBonus(true, platform);
        }
    }

    private Vector2 GetPlatformPosition()
    {
        float randomX = Random.Range(mainData.LeftBoundModified, mainData.RightBoundModified);
        Vector2 randomPoint = new Vector2(randomX, pointToSpawn.position.y);
        return randomPoint;
    }

    private void SpawnPlatformObject(PlatformTypes platformType)
    {
        BonusAbstract bonus = SetBonus(platformType);
        Vector2 platformPosition = GetPlatformPosition();
        PlatformAbstract platform = platformPooler.GetPlatformFromPool(platformType);
        if (bonus)
            PlatformSpawn(platform, platformPosition, bonus);
        else
            PlatformSpawn(platform, platformPosition);
    }

    private BonusAbstract CheckOnType(bool isOriginal)
    {
        if (isOriginal)
        {
            BonusType bonusType = bonusPooler.RandomSpawn();
            if (bonusType != BonusType.None && bonusType != BonusType.Reverse)
            {
                BonusAbstract _bonus = bonusPooler.GetBonus(bonusType);
                if (_bonus != null)
                    return _bonus;

                if (_bonus == null)
                {
                    BonusAbstract bonus = bonusPooler.GetBonusElse(bonusType);
                    return bonus;
                }
            }
        }

        return null;
    }

    private BonusAbstract SetBonus(PlatformTypes type)
    {
        bool isOriginal = bonusPooler.CheckTypePlatform(type);
        BonusAbstract bonus = CheckOnType(isOriginal);
        return bonus;
    }
}