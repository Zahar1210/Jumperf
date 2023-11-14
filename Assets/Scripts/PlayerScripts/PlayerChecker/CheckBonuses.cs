using UnityEngine;

public class CheckBonuses : MonoBehaviour
{
    [SerializeField] private PlayerJumpTracking playerJumpTracking;
    [SerializeField] private PlayerUseBonusDisplayManager playerUseBonusDisplay;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;
    
    void Update()
    {
        Collider2D _bonus = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (_bonus && !playerJumpTracking.isUp)
        { 
            BonusAbstract bonus = _bonus.GetComponent<BonusAbstract>();
            bonus?.Action();
            bonus?.UseBonus();
            playerUseBonusDisplay.GetActiveBonus(bonus.Type);
            AudioController.Instance.PlayAudio("PlayerTakeBonus");
        }
    }
}