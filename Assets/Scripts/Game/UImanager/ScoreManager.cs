using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int point;
    
    [SerializeField] private Text pointText;
    
    private Transform _playerPosition;

    private void Start()
    {
        _playerPosition = PlayerBehaviour.Instance.transform;
    }

    private void Update()
    {
        UpdatePoint((int)_playerPosition.position.y);
    }

    private void UpdatePoint(int newPoint)
    {
        point = (newPoint >= point) ? newPoint : point;
        pointText.text = point.ToString();
    }
}