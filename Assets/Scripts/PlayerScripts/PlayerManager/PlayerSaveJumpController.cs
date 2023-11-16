using UnityEngine;

public class PlayerSaveJumpController : MonoBehaviour
{
    [SerializeField] private SliderController slider;
    private PlayerBehaviour _player;

    private void Start()
    {
        _player = PlayerBehaviour.Instance;
    }

    void Update()
    {
        // if (Input.GetMouseButtonUp(0) && slider.isReady)
        // {
            // _player.BoostJump();
            // slider.StartCoroutine();
        // }
    }
}