using UnityEngine;

public class BlinkingPlatform : PlatformAbstract
{
    [SerializeField] private Animator animator;
    private float _time;

    public override void Action()
    {
        PlayerBehaviour player = PlayerBehaviour.Instance;
        AudioController.Instance.PlayAudio("PlayerJump1");
        player.Jump();
    }

    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("loop", true);
    }
}