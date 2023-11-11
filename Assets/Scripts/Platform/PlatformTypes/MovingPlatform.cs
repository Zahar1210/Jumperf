using UnityEngine;

public class MovingPlatform : PlatformAbstract
{
    [SerializeField] private float platformSpeed;

    private MainData _mainData;
    private float _platformWidth;
    private int _direction = 1;

    private Vector2 _rotationRight;
    private Vector2 _rotationLeft;

    private void Start()
    {
        _rotationLeft = new Vector2(0, -180);
        _rotationRight = new Vector2(0, 0);
        _platformWidth = transform.localScale.x;
        MainData mainData = GameObject.FindGameObjectWithTag("MainData").GetComponent<MainData>();
        _mainData = mainData;
    }

    public override void Action()
    {
        PlayerBehaviour player = PlayerBehaviour.Instance;
        player.Jump();
    }

    public override void EnablePlatform(bool isSpawn)
    {
        Bonus = null;
        IsActive = isSpawn;
        gameObject.SetActive(isSpawn);
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.right * platformSpeed * _direction * Time.deltaTime;
        gameObject.transform.position = newPosition;

        if (_direction == 1 && transform.position.x + _platformWidth / 2 > _mainData.RightBound)
            ChangeRotation(_rotationLeft, true);

        else if (_direction == -1 && transform.position.x - _platformWidth / 2 < _mainData.LeftBound)
            ChangeRotation(_rotationRight, false);
    }

    private void ChangeRotation(Vector2 rotation, bool isLeft)
    {
        Quaternion newRotation = Quaternion.Euler(rotation);
        transform.rotation = newRotation;
        _direction = isLeft ? -1 : 1;
    }
}