using UnityEngine;

public abstract class PlatformAbstract : MonoBehaviour
{
    public BonusAbstract Bonus;

    public PlatformTypes PlatformType;

    public abstract void Action();

    public abstract void EnablePlatform(bool isSpawn);
}