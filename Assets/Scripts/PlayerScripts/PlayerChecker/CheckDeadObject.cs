using UnityEngine;

public class CheckDeadObject : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;

    private bool _isDead;
    
    void FixedUpdate()
    {
        Collider2D overlapCircle = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (overlapCircle && !PlayerBehaviour.Instance.IsDead)
        {
            PlayerBehaviour.Instance.IsDead = true;
            PlayerDeadWithFall playerDeadObject = overlapCircle.GetComponent<PlayerDeadWithFall>();
            playerDeadObject.Die();
        }
    }
}