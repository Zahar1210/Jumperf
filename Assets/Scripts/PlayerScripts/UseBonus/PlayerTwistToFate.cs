using UnityEngine;

public class PlayerTwistToFate : MonoBehaviour
{
    public bool useReverse;
    
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int intervalScore;

    private int _limitScore;
    private PlayerBehaviour _player;

    private void Update()
    {
        if (useReverse && scoreManager.point > _limitScore)
        {
            _player.EnableUseReverse();
        }
    }

    public void SetLimitToUseBonus()
    {
        _limitScore = scoreManager.point + intervalScore;
    }
}