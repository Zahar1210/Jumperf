using UnityEngine;

[CreateAssetMenu(fileName = "BonusInfo", menuName = "Info/Bonus")]
public class BonusInfo : ScriptableObject
{
   [SerializeField] private BonusType bonusType;
   [SerializeField] private float chance;

   public BonusType BonusType => bonusType;
   public float Chance => chance;
}

