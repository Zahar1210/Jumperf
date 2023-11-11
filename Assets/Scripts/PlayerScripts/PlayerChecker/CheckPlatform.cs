using UnityEngine;
using UnityEngine.Serialization;

public class CheckPlatform : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private PlayerJumpTracking playerJumpTracking;
    [SerializeField] private LayerMask layerMask;

    private void FixedUpdate()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (collider2D && !playerJumpTracking.isUp)
        {
            PlatformAbstract platformAbstract = collider2D.GetComponent<PlatformAbstract>();
            platformAbstract?.Action();
        }
    }
}