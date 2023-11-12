using UnityEngine;

public class PlayerDeadWithFall : MonoBehaviour
{
    [SerializeField] private Transform parentCamera;
    [SerializeField] private CheckingFall fall;
    [SerializeField] private PlayerJumpTracking playerJumpTracking;
    [SerializeField] private PlayModeController modeController;

    private void Update()
    {
        if (!fall.isFalling)
            gameObject.transform.SetParent(!playerJumpTracking.isUp ? null : parentCamera);
    }

    public void Die()
    {
        modeController.ActivePanel();
    }
}