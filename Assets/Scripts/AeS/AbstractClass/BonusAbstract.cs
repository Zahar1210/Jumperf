using UnityEngine;

public abstract class BonusAbstract : MonoBehaviour
{
    public SpriteRenderer Sprite;

    public BonusType Type;

    public bool IsActive;

    public PlatformAbstract Platform;

    public Vector3 SpawnPosition;

    public Collider2D Collider;

    public abstract void Action();
    public abstract void EnableBonus(bool isSpawn, PlatformAbstract platform);
    public abstract void UseBonus();
}