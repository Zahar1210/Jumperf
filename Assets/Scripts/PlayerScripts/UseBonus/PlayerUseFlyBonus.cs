using UnityEngine;

public class PlayerUseFlyBonus : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private float flyForceCap;
    [SerializeField] private float flyForceJetpack;
    [SerializeField] private int intervalScoreCap;
    [SerializeField] private int intervalScoreJetPack;

    private int _limitScore;
    private Rigidbody2D _rigidbody;

    private bool _useCap;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_useCap)
            _rigidbody.AddForce(Vector2.up * flyForceCap * Time.fixedTime, ForceMode2D.Force);
        else
            _rigidbody.AddForce(Vector2.up * flyForceJetpack * Time.fixedTime, ForceMode2D.Force);
        
        if (scoreManager.point >= _limitScore)
        {
            player.EnableUseBonus();
            player.UsageBonus();
        }
    }
    
    public void SetLimitToUseBonus(bool isCap)
    {
        if (isCap)
        {
            _limitScore = scoreManager.point + intervalScoreCap;
            _useCap = true;
        }
        else
        {
            _limitScore = scoreManager.point + intervalScoreJetPack;
            _useCap = false;
        }
    }
}