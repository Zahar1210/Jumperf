using UnityEngine;

public class FakePlatform : PlatformAbstract
{
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private Animator animator;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public override void Action()
    {
        animator.SetBool("isTach", true);
    }

    public void GetCondition()
    {
        _collider2D.enabled = false;
    }
    
    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }
}