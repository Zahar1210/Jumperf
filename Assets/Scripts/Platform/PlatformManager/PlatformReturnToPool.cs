using System;
using UnityEngine;

public class PlatformReturnToPool : MonoBehaviour
{
    [SerializeField] private PlatformPooler platformPool;
    [SerializeField] private Vector2 size;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, size, Quaternion.identity.eulerAngles.z,
            layerMask, -Mathf.Infinity, Mathf.Infinity);
        foreach (var platformCollider in colliders)
        {
            ProcessPlatformCollider(platformCollider);
        }
    }

    private void ProcessPlatformCollider(Collider2D platformCollider)
    {
        PlatformAbstract platform = platformCollider.GetComponent<PlatformAbstract>();
        if (platform != null)
        {
            BonusAbstract bonus = platform.Bonus;
            if (bonus) {
                bonus.EnableBonus(false, null);
            }

            platform.EnablePlatform(false);
        }
    }
}