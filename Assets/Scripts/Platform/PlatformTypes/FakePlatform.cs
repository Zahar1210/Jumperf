using UnityEngine;

public class FakePlatform : PlatformAbstract
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite; 
    
    public override void Action()
    {
        animator.SetBool("isTach", true);
    }

    public void GetCondition()
    {
        animator.SetBool("isTach", false);
        sprite.enabled = false;
    }
    
    public override void EnablePlatform(bool isSpawn)
    {
        sprite.enabled = isSpawn;
        gameObject.SetActive(isSpawn);
        Bonus = null;
    }
}