using UnityEngine;
using Random = UnityEngine.Random;

public class BonusPooler : MonoBehaviour
{
    [SerializeField] private BonusAbstract[] bonuses;
    [SerializeField] private BonusInfo[] bonusInfo;
    [SerializeField] private int chanceSpawnBonus;
    
    private BonusType _bonusType;
    private float _totalChance;

    private void Start()
    {
        float totalChance = 0f;
        for (int i = 0; i < bonuses.Length; i++)
        {
            BonusAbstract bonus = Instantiate(bonuses[i]);
            bonus.gameObject.SetActive(false);
        }

        foreach (var bonus in bonusInfo){
            totalChance += bonus.Chance;
        }
        
        _totalChance = totalChance;
    }

    private BonusType GetRandomBonus()
    {
        float randomValue = Random.Range(0, _totalChance);
        foreach (var bonus in bonusInfo)
        {
            if (randomValue > bonus.Chance)
                randomValue -= bonus.Chance;
            else
                return bonus.BonusType;
        }
        return BonusType.None;
    }

    public BonusAbstract GetBonus(BonusType bonusType)
    {
        BonusAbstract[] bonusAbstracts = FindObjectsOfType<BonusAbstract>(true);
        foreach (BonusAbstract bonus in bonusAbstracts)
        {
            if (bonus.Type == bonusType && !bonus.IsActive)
                return bonus;
        }
        return null;
    }
    
    public BonusAbstract GetBonusElse(BonusType bonusType)
    {
        BonusAbstract bonus = GetNewBonus(bonusType);
        BonusAbstract bonusSpawn = Instantiate(bonus);
        return bonusSpawn;
    }
    
    private BonusAbstract GetNewBonus(BonusType bonusType)
    { 
        BonusAbstract bonus = bonuses[2];
        foreach (BonusAbstract prefab in bonuses)
        {
            if (prefab.Type == bonusType)
                return prefab;
        }
        return bonus;
    }
    
    public bool CheckTypePlatform(PlatformTypes platformTypes)
    {
        switch (platformTypes)
        {
            case PlatformTypes.Original:
                return true;
            case PlatformTypes.Moving:
                return true;
            default:
                return false;
        }
    }
    
    public BonusType RandomSpawn()
    {
        int randomIndex = Random.Range(1, chanceSpawnBonus);
        if (randomIndex == 1)
        {
            _bonusType = GetRandomBonus();
            return _bonusType;
        }
        return BonusType.None;
    }
}
