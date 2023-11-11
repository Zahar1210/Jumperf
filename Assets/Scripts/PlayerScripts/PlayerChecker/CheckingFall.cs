using UnityEngine;

public class CheckingFall : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private float timeDeath;
    [SerializeField] private float timeSave;

    private Rigidbody2D _rb;
    public bool isFalling = true;

    private float _timeFalling;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalSpeed = _rb.velocity.y;
        _timeFalling = verticalSpeed < 0 ? _timeFalling + Time.deltaTime : 0;

        if (_timeFalling >= timeSave && !player.UseCap && !player.UseJetpack)
            player.IsSave = false;

        if (_timeFalling >= timeDeath && !player.UseJetpack && !player.UseCap && isFalling)
        {
            isFalling = false;
            player.Dead();
        }
    }
}