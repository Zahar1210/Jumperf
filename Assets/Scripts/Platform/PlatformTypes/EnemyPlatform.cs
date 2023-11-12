using UnityEngine;

public class EnemyPlatform : PlatformAbstract
{
    public bool condition;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteAngry;
    [SerializeField] private Sprite spritePeace;
    [SerializeField] private int timeChange;
    [SerializeField] private float platformSpeed;
    [SerializeField] private Animator animator;

    private Vector2 _rotationRight;
    private Vector2 _rotationLeft;
    private MainData _mainData;
    private PlayerBehaviour player;
    private float _platformWidth;
    private float _time;
    private int _direction = 1;
    private string _beforeAnimation;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _rotationLeft = new Vector2(0, -180);
        _rotationRight = new Vector2(0, 0);
        player = PlayerBehaviour.Instance;
        _platformWidth = transform.localScale.x;
        MainData mainData = GameObject.FindGameObjectWithTag("MainData").GetComponent<MainData>();
        _mainData = mainData;
    }

    private void Update()
    {
        ChangeCondition();
        Moving();
    }

    public override void Action()
    {
        if (condition)
            player.Jump();
        else
            player.Contusion(false);
    }

    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }

    private void ChangeCondition()
    {
        _time += Time.deltaTime;
        if (_time >= timeChange)
        {
            if (condition)
            {
                SetAnimation(false);
            }
            else if (!condition)
            {
                SetAnimation(true);
            }

            _time = 0f;
        }
    }

    private void Moving()
    {
        Vector3 newPosition = transform.position + Vector3.right * platformSpeed * _direction * Time.deltaTime;
        gameObject.transform.position = newPosition;

        if (_direction == 1 && transform.position.x + _platformWidth / 2 > _mainData.RightBound)
            ChangeRotationEnemy(_rotationLeft, true);

        else if (_direction == -1 && transform.position.x - _platformWidth / 2 < _mainData.LeftBound)
            ChangeRotationEnemy(_rotationRight, false);
    }

    private void ChangeRotationEnemy(Vector2 rotation, bool isLeft)
    {
        Quaternion newRotation = Quaternion.Euler(rotation);
        transform.rotation = newRotation;
        _direction = isLeft ? -1 : 1;
    }

    public void ChangeSpriteAngry()
    {
        condition = false;
        spriteRenderer.sprite = spriteAngry;
    }

    public void ChangeSpritePeace()
    {
        condition = true;
        spriteRenderer.sprite = spritePeace;
    }

    private void SetAnimation(bool isChange)
    {
        animator.SetBool("isChange", isChange );
    }
}