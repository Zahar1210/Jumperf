using UnityEngine;

public class ChangingPlatform : PlatformAbstract
{
    [SerializeField] private int _timeChange;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spritePeace;
    [SerializeField] private Sprite _spriteAngry;

    private bool _condition;
    private float _time;


    public override void Action()
    {
        PlayerBehaviour player = PlayerBehaviour.Instance;
        if (_condition) {
            AudioController.Instance.PlayAudio("PlayerJump1");
            player.Jump();
        }

        else
        {
            AudioController.Instance.PlayAudio("PlayerDie");
            player.Contusion(false);
        }
    }

    public override void EnablePlatform(bool isSpawn)
    {
        gameObject.SetActive(isSpawn);
        Bonus = null;
    }

    private void Start()
    {
        _condition = true;
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeChange)
        {
            if (_condition)
            {
                _condition = false;
                _spriteRenderer.sprite = _spriteAngry;
            }
            else if (!_condition)
            {
                _condition = true;
                _spriteRenderer.sprite = _spritePeace;
            }

            _time = 0f;
        }
    }
}