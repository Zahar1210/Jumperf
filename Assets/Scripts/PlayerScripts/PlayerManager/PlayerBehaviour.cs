using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance { get; private set; }

    public float startJumpForce;
    public float jumpForce;

    [SerializeField] private float usageFlyBonusJumpForce;
    [SerializeField] private float startJump;
    [SerializeField] private float boostForce;
    [SerializeField] private float startGravityScale;
    [SerializeField] private float decreaseJumpForce;

    [SerializeField] private PlayerUseBonusDisplayManager useBonusDisplay;
    [SerializeField] private PlayerUseSnareBonus playerUseSnare;
    [SerializeField] private PlayerUseMysteryBonus playerUseMystery;
    [SerializeField] private PlayerUseFlyBonus playerUseFly;
    [SerializeField] private PlayerDead playerDead;
    [SerializeField] private CheckBonuses check;
    [SerializeField] private CheckDeadObject checkDead;
    [SerializeField] private PlayerTwistToFate reverse;

    private Rigidbody2D _rigidbody;
    private bool _isDeath;
    private int _jumpCount;
    private float _time;
    
    public bool IsDead { get; set; }
    public bool UseJetpack { get; private set; }
    public bool UseCap { get; private set; }
    public bool UseJumpBonus { get; set; }
    public bool JumpUpBonus { get; set; }
    public bool JumpDownBonus { get; set; }
    public bool UseReverseBonus { get; set; }
    public bool IsSave { get; set; } = true;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DieContusionBonus()
    {
        useBonusDisplay.PlayActiveBonusAnimation( Vector2.zero, "isContusion");
        jumpForce -= decreaseJumpForce;
        Jump();
        playerUseSnare.Contusion();
    }

    private void UsageBonusJump()
    {
        jumpForce += usageFlyBonusJumpForce;
        Jump();
        jumpForce -= usageFlyBonusJumpForce;
    }
    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playerUseMystery.IsBonusUsed();
    }

    public void JumpBonus(bool isBonus)
    {
        playerUseMystery.UseMysteryBonus(isBonus);
    }

    public void BoostJump()
    {
        jumpForce += boostForce;
        Jump();
        jumpForce -= boostForce;
    }

    public void StartJump()
    {
        jumpForce += startJump;
        Jump();
        jumpForce -= startJump;
    }

    public void Dead()
    {
        if (!_isDeath)
        {
            checkDead.enabled = true;
            playerDead.DieFromFall();
            _isDeath = true;
        }
    }

    public void Fly(bool isCap)
    {
        playerUseFly.enabled = true;
        playerUseFly.SetLimitToUseBonus(isCap);
        UseBonus(isCap);
    }

    private void UseBonus(bool isCap)
    {
        _rigidbody.gravityScale = 0;
        check.gameObject.SetActive(false);
        if (isCap)
            UseCap = true;
        else
            UseJetpack = true;
    }

    public void UsageBonus()
    {
        _rigidbody.gravityScale = startGravityScale;
        check.gameObject.SetActive(true);
        playerUseFly.enabled = false;
        UsageBonusJump();
        UseCap = false;
        UseJetpack = false;
    }

    public void EnableUseBonus()
    {
        useBonusDisplay.DeactivateBonusAnimation();
    }

    public void Reverse()
    {
        UseReverseBonus = true;
        reverse.SetLimitToUseBonus();
        reverse.useReverse = true;
    }

    public void EnableUseReverse()
    {
        reverse.useReverse = false;
        UseReverseBonus = false;
    }
}