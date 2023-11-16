public class DeadPlatform : PlatformAbstract
{
    public override void Action()
    {
        PlayerBehaviour.Instance.Contusion(false);//пока так 
    }
    public override void EnablePlatform(bool isSpawn)
    {
        gameObject.SetActive(isSpawn);
        Bonus = null;
    }
}