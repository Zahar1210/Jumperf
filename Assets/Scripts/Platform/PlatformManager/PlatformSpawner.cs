using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private BonusPooler bonusPooler;
    [SerializeField] private PlatformPooler platformPooler;
    [SerializeField] private MainData mainData;
    [SerializeField] private Transform pointToSpawn;
    [SerializeField] private int maxConsecutiveSpawnsBad;
    [SerializeField] private List<PlatformTypes> badPlatformTypes;
    [SerializeField] private GameObject point;

    private int _consecutiveSpawnsGood;
    private int _consecutiveSpawnsBad;
    private int _spawnCount;
    private float _time;
    private PlatformTypes _randomType;

    public void SpawnPlatform()
    {
        _randomType = platformPooler.GetRandomType();
        TryPlatformType();
    }

    private void TryPlatformType()
    {
        if (badPlatformTypes.Contains(_randomType)) {
            _consecutiveSpawnsBad++;
            if (_consecutiveSpawnsBad <= maxConsecutiveSpawnsBad) {
                SpawnPlatformObject(_randomType);
            }
            else {
                SpawnPlatform();
                _consecutiveSpawnsBad = 0;
            }
        }
        else {
            SpawnPlatformObject(_randomType);
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
        PlatformSpawn(platform, platformPosition, bonus ? bonus : null);
    }

    private BonusAbstract CheckOnType(bool isOriginal)
    {
        if (isOriginal)
        {
            BonusType bonusType = bonusPooler.RandomSpawn();
            if (bonusType != BonusType.None)
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