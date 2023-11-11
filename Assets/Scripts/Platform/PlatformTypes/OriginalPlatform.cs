public class OriginalPlatform : PlatformAbstract
{
    public override void Action()
    {
        PlayerBehaviour.Instance.Jump();
    }

    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }
}