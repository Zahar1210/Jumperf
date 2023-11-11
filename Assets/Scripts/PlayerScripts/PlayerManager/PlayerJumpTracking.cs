using UnityEngine;

public class PlayerJumpTracking : MonoBehaviour
{
    public bool isUp;
    private float _previousYPosition;

    void Start()
    {
        _previousYPosition = transform.position.y;
    }

    void Update()
    {
        float currentYPosition = transform.position.y;
        
        if (currentYPosition > _previousYPosition)
            isUp = true;
        else if (currentYPosition < _previousYPosition)
            isUp = false;
        
        _previousYPosition = currentYPosition;
    }
}