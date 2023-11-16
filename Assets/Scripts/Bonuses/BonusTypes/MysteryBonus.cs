using UnityEngine;
using Random = UnityEngine.Random;

public class MysteryBonus : BonusAbstract
{
    private PlayerBehaviour _player;
    [SerializeField] private Animator animator;
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
        animator.SetBool("isMystary", true);
        if (!_player.UseJumpBonus)
        {
            bool useJumpBonus = (Random.Range(0, 2) == 0);
            _player.JumpBonusUse(useJumpBonus);
        }
        else
        {
            Debug.Log("фигушки");
        }
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
            Sprite.enabled = false;
            IsActive = false;
            Platform.Bonus = null;
            Platform = null;
            gameObject.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }
}