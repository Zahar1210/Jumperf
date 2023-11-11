public class CapBoost : BonusAbstract
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
        _player.Fly(true);
    }

    public override void EnableBonus(bool isSpawn, PlatformAbstract platform)
    {
        if (isSpawn)
        {
            Collider.enabled = true;
            Sprite.enabled = true;
            IsActive = true;
            Platform = platform;
            gameObject.SetActive(true);
            gameObject.transform.SetParent(Platform.transform);
            transform.localPosition = SpawnPosition;
        }
        else
        {
            Collider.enabled = false;
            Sprite.enabled = true;
            IsActive = false;
            Platform.Bonus = null;
            Platform = null;
            gameObject.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }
}