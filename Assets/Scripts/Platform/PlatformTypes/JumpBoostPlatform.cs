using UnityEngine;

public class JumpBoostPlatform :  PlatformAbstract
{ 
    [SerializeField] private Animator animator;
    public  override void Action()
    {
        animator.SetBool("isBoost", true);
        PlayerBehaviour.Instance.BoostJump();
    }
    
    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }
}
