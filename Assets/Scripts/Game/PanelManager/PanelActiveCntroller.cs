using UnityEngine;

public class PanelActiveCntroller : MonoBehaviour
{
    public PanelController panel;
    [SerializeField] private PlayModeController playMode;
    [SerializeField] private RestartPlayController restart;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && panel.IsActive)
        {
            Vector2 clickPosition = Input.mousePosition;
            if (panel.gameObject.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), clickPosition))
            {
                if (PlayerBehaviour.Instance.IsDead)
                {
                    restart.RestartPlay();
                }

                playMode.ActivePanel();
            }
        }
    }
}