public class DeadPlatform : PlatformAbstract
{
    public override void Action()
    {
        PlayerBehaviour.Instance.DieContusionBonus(false);//пока так (название метода)
    }
    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }
}