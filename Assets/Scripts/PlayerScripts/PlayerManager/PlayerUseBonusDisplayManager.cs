using UnityEngine;

public class PlayerUseBonusDisplayManager : MonoBehaviour
{
    [SerializeField] private Vector2 jetpackPosition;
    [SerializeField] private Vector2 capPosition;
    [SerializeField] private Vector2 snarePosition;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;

    private string _nameAnimation;
    private bool _useBonus;

    public void GetActiveBonus(BonusType type)
    {
        string nameAnimation = null;
        Vector2 pos = new Vector2(0, 0);
        switch (type)
        {
            case BonusType.CapBonus:
                pos = capPosition;
                nameAnimation = "isCap";
                break;
            case BonusType.JetpackBonus:
                pos = jetpackPosition;
                nameAnimation = "isJetpack";
                break;
            case BonusType.MysteryBonus:
                nameAnimation = "isMystery";
                break;
            case BonusType.Snare:
                pos = snarePosition;
                nameAnimation = "isSnare";
                break;
            case BonusType.None:
                break;
        }
        
        if (nameAnimation != null && !_useBonus)
        {
            _useBonus = true;
            PlayActiveBonusAnimation(pos, nameAnimation);
        }
        else
        {
            DeactivateBonusAnimation();
            PlayActiveBonusAnimation(pos, nameAnimation);
        }
    }

    public void PlayActiveBonusAnimation(Vector2 bonusPosition, string nameAnimation)
    {
        animator.gameObject.SetActive(true);
        animator.gameObject.transform.localPosition = bonusPosition;
        animator.SetBool(nameAnimation, true);
        _nameAnimation = nameAnimation;
    }

    public void DeactivateBonusAnimation()
    {
        _useBonus = false;
        sprite.sprite = null;
        animator.SetBool(_nameAnimation, false);
        animator.gameObject.SetActive(false);
        animator.gameObject.transform.localPosition = Vector3.zero;
        _nameAnimation = null;
    }
}