public class StartPlatform : PlatformAbstract
{
    public bool isStart;

    public override void Action()
    {
        PlayerBehaviour player = PlayerBehaviour.Instance;

        if (!isStart)
        {
            player.Jump();
            AudioController.Instance.PlayAudio("PlayerJump1");
        }
        else if (isStart)
        {
            player.StartJump();
            EnablePlatform(false);
        }
    }

    public override void EnablePlatform(bool isSpawn)
    {
        gameObject.SetActive(isSpawn);
    }
}