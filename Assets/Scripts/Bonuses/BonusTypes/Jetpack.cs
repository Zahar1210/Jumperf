public class Jetpack : BonusAbstract
{
    private PlayerBehaviour _player;

    private void Start()
    {
        _player = PlayerBehaviour.Instance;
    }

    public override void UseBonus()
    {
        Collider.enabled = false;
        Sprite.enabled = false;
    }

    public override void Action()
    {
        _player.Fly(false);
    }

    public override void EnableBonus(bool isSpawn, PlatformAbstract platform)
    {
        if (isSpawn)
        {
            Collider.enabled = true;
            IsActive = true;
            Platform = platform;
            Sprite.enabled = true;
            gameObject.SetActive(true);
            gameObject.transform.SetParent(Platform.transform);
            transform.localPosition = SpawnPosition;
        }
        else
        {
            Collider.enabled = false;
            Sprite.enabled = false;
            IsActive = false;
            Platform.Bonus = null;
            Platform = null;
            gameObject.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }
}