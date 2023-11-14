public class OriginalPlatform : PlatformAbstract
{
    public override void Action()
    {
        PlayerBehaviour.Instance.Jump();
        AudioController.Instance.PlayAudio("PlayerJump1");
    }

    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }
}